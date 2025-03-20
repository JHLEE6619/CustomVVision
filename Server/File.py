import os
import numpy as np
from PIL import Image

class File_handler:
    def makedirs(self, directory):
        if not os.path.exists(directory):
            os.makedirs(directory)

    def load_img(self, directory):
        images = []
        for fileName in os.listdir(directory):
            if fileName.endswith(('.jpg','.png','jpeg')):
                imgDir = os.path.join(directory, fileName)
                img = Image.open(imgDir).resize((416,416))
                img_array = np.array(img)
                images.append(img_array)
        return np.array(images) / 255.0 # 하나의 레이블에 해당하는 이미지 ndarray 반환


