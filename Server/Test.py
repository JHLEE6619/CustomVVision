# 딥러닝에 필요한 케라스 함수 호출
from keras.models import load_model
# 필요 라이브러리 호출(PIL은 이미지파일 처리위함)
from PIL import Image
import numpy as np

class Test:
    def Test_model(self, imagePath, modelInfo):
        # 이미지 불러오기
        img = Image.open(imagePath)

        # 이미지 사이즈를 모델에 맞는 사이즈로 조정
        img = np.resize(img, (modelInfo['ColorType'], modelInfo['ImageWidth'], modelInfo['ImageHeight']))

        # 데이터를 모델에 적용할 수 있도록 가공
        test_data = ((np.array(img) / 255) - 1) * -1

        # 모델 불러오기
        model = load_model(modelInfo['ModelDir'])

        # 클래스 예측 함수에 가공된 테스트 데이터 넣어 결과 도출
        result = model.predict(test_data)

        # 가장 확률이 높은 확률을 가진 인덱스 추출
        idx = np.argmax(result)

        # 인덱스로 예측결과 레이블 인덱싱
        prediction = modelInfo["Labels"][idx]

        return prediction

