import base64
import os
import numpy as np
import pandas as pd
from PIL import Image

class File_handler:

    def makedirs(self, directory):
        if not os.path.exists(directory):
            os.makedirs(directory)

    def load_img(self, directory):
        images = []
        for fileName in os.listdir(directory):
            if fileName.endswith(('.jpg','.png','.jpeg')):
                imgDir = os.path.join(directory, fileName)
                img = Image.open(imgDir).resize((416,416))
                img_array = np.array(img)
                images.append(img_array)
        return np.array(images) / 255.0 # 하나의 레이블에 해당하는 이미지 ndarray 반환

    def load_image(self, modelId, labels, imgWidth, imgHeight):
        imgList = []
        labelList = []
        for label in labels:
            imgDir = os.path.join('models', modelId, label)
            print(imgDir)
            for fileName in os.listdir(imgDir):
                if fileName.endswith(('.jpg', '.png', '.jpeg')):
                    imgName = os.path.join(str(imgDir),fileName)
                    img = Image.open(imgName).resize((imgWidth, imgHeight))
                    img_arr = np.array(img)
                    imgList.append(img_arr)
                    labelList.append(label)
        print("이미지 리스트에 담기 완료")
        imgList = np.array(imgList) / 255.0
        print("이미지 ndarray로 전환하고 정규화 완료")
        return imgList, labelList

    def recv_file(self, file):
        file_name = os.path.join("test", "test_image.jpg")
        file = base64.b64decode(file)
        # 바이너리 파일 쓰기 모드
        with open(file_name, "wb") as f:
            f.write(file)
        # self.fileName += 1
        return file_name

    def send_file(self, fileName):
        with open(f"{fileName}", 'rb') as f:
            data = f.read(1024)
        return base64.b64encode(data).decode('utf-8')
