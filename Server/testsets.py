import os.path

from keras.models import load_model
# 필요 라이브러리 호출(PIL은 이미지파일 처리위함)
from PIL import Image
import numpy as np

def Test_model():
    # 이미지 불러오기
    imagePath = os.path.join("test","test_image.jpg")
    img = Image.open(imagePath)
    print("이미지 불러오기 완료")
    # 이미지 사이즈를 모델에 맞는 사이즈로 조정
    img = img.resize((224, 224))
    print("resize 완료")
    # 데이터를 모델에 적용할 수 있도록 가공
    test_data = np.array(img) / 255.0
    test_data = test_data.reshape(1, 224, 224, 3)
    print("전처리 완료")
    # 모델 불러오기
    modelFile = os.path.join("models","animal2","animal2.keras")
    model = load_model(modelFile)
    print("모델 불러오기 완료")
    # 클래스 예측 함수에 가공된 테스트 데이터 넣어 결과 도출
    result = model.predict(test_data)
    print("테스트 완료")
    print(result)
    # 가장 확률이 높은 확률을 가진 인덱스 추출
    idx = np.argmax(result)
    print("인덱스 추출 완료")
    # 인덱스로 예측결과 레이블 인덱싱
    labels = ["Dog","Dolphin","Elephant","Giraffe","Horse"]
    prediction = labels[idx]
    print("레이블 인덱싱 완료")
    print(f"예측 : {prediction}")
    return prediction

Test_model()