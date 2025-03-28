import os.path

from sklearn.model_selection import train_test_split
from tensorflow.keras.models import Sequential
from tensorflow.keras.layers import Dense, Dropout, Flatten, Conv2D, MaxPooling2D
from tensorflow.keras.callbacks import ModelCheckpoint,EarlyStopping
from tensorflow.keras.utils import to_categorical
import tensorflow as tf
import pandas as pd
import File


class CNN:
    # gpu 메모리를 가능한 만큼만 할당
    # os.environ["TF_GPU_ALLOCATOR"] = "cuda_malloc_async"
    gpus = tf.config.experimental.list_physical_devices('GPU')
    if gpus:
        try:
            # 동적 메모리 할당 설정
            for gpu in gpus:
                tf.config.experimental.set_memory_growth(gpu, True)
        except RuntimeError as e:
            print(e)

    # labels는 db에서 조회 후 리스트에 담고 전달인자로 사용하고 이미지 경로에 사용
    file = File.File_handler()
    def DeepLearing(self, modelInfo, labels):
        modelDir = os.path.join('models',modelInfo["ModelId"])
        # 분류 기준에 따른 활성화 함수 분기
        # 데이터를 불러오고 X,y를 지정
        X, y = self.file.load_image(modelInfo["ModelId"], labels, modelInfo['ImageWidth'], modelInfo['ImageHeight']) ###
        print(f"X[0] : \n{X[0]}")
        print("이미지 로드 완료")
        y = pd.get_dummies(y)
        print("원-핫 인코딩 완료")
        print(y.head(5))
        # stratify = y : 레이블 데이터 y에 따라 학습 데이터셋과 테스트 데이터셋의 클래스 비율이 유지된다.
        X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, stratify=y)
        print("학습셋 테스트셋 구분 완료")
        print(f"X_train : {X_train[10]}")
        print(f"X_test : {X_test[10]}")
        print(f"y_train : {y_train}")
        print(f"y_test : {y_test}")
        X_train = X_train.reshape(X_train.shape[0], modelInfo['ImageWidth'], modelInfo['ImageHeight'], modelInfo['ColorType']) ###
        X_test = X_test.reshape(X_test.shape[0], modelInfo['ImageWidth'], modelInfo['ImageHeight'], modelInfo['ColorType']) ###
        print("reshape 완료")

        print("X_train shape: {} \nY_train shape: {}".format(X_train.shape, y_train.shape))
        print("X_test shape: {} \nY_test shape: {}".format(X_test.shape, y_test.shape))


        # 컨볼루션 신경망의 설정
        activation, loss = self.classification(modelInfo['Classification']) ###

        model = Sequential()
        model.add(Conv2D(32, kernel_size=(3, 3),
                         input_shape=(modelInfo['ImageWidth'], modelInfo['ImageHeight'], modelInfo['ColorType']), activation='relu')) ###
        model.add(Conv2D(64, (3, 3), activation='relu'))
        model.add(MaxPooling2D(pool_size=(2,2)))
        model.add(Dropout(0.25))
        model.add(Flatten())
        model.add(Dense(128,  activation='relu'))
        model.add(Dropout(0.5))
        print(f"활성화 함수 : {activation}")
        print(f"손실함수 : {loss}")
        model.add(Dense(len(labels), activation=activation)) ####

        # 모델의 실행 옵션을 설정합니다.
        model.compile(loss=loss,
                      optimizer='adam',
                      metrics=['accuracy'])

        # 모델 저장경로 설정
        modelPath = os.path.join(modelDir , modelInfo["ModelId"] + '.keras') ###

        # 모델 최적화를 위한 설정 구간입니다.
        checkpointer = ModelCheckpoint(filepath=modelPath, monitor='val_loss', verbose=1, save_best_only=True)
        early_stopping_callback = EarlyStopping(monitor='val_loss', patience=20)
        print("체크포인터 설정완료")

        # 모델을 실행합니다.
        history = model.fit(X_train, y_train, validation_split=0.25, epochs=modelInfo["Epoch"], batch_size=64, verbose=0,
                            callbacks=[early_stopping_callback, checkpointer]) ###

        # 테스트 정확도를 출력합니다.
        print("\n Test Accuracy: %.4f" % (model.evaluate(X_test, y_test)[1]))

    def classification(self, classification):
        if classification: # 다항 분류
            activation = 'softmax'
            loss = 'categorical_crossentropy'
        else: # 이항 분류
            activation = 'sigmoid'
            loss = 'binary_crossentropy'
        return activation, loss

