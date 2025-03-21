import os
import numpy as np
import pandas as pd
from PIL import Image

class File_handler:
    fileName = 0

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

    def load_image(self, modelDir, labels, imgWidth, imgHeight):
        imgList = []
        labelList = []
        for label in labels:
            imgDir = os.path.join(modelDir, label)
            for fileName in os.listdir(str(imgDir)):
                if fileName.endswith(('.jpg', '.png', '.jpeg')):
                    imgName = os.path.join(str(imgDir),fileName)
                    img = Image.open(imgName).resize((imgWidth, imgHeight))
                    img_arr = np.array(img)
                    imgList.append(img_arr)
                    labelList.append(label)

        imgList = np.array(imgList) / 255.0

        return pd.Series(imgList), pd.Series(labelList)

    def recv_file(self, file):
        file_name = f'{self.fileName}.jpg'
        # 바이너리 파일 쓰기 모드
        with open(file_name, "wb") as f:
            f.write(file)
        self.fileName += 1
        return file_name

    def send_file(self, fileName):
        with open(f"{fileName}", 'rb') as f:
            while True:
                data = f.read(1024)
                if not data:
                    break
        return data
