import pymysql
import os

class DBC:

    def __init__(self):
        try:
            self.conn = pymysql.connect(host='127.0.0.1', port=3306,
                                   user='root', password='1234',
                                   db='custom_vvision', charset='utf8')
            self.cursor = self.conn.cursor()
        except Exception as e:
            print("DB 접속 에러")
            print(e)
            return
        print("DB 접속 성공")

    def join(self, userInfo):
        userId = userInfo['UserId']
        pw = userInfo['Pw']
        userName = userInfo['UserName']

        sql = 'INSERT INTO USER VALUES (%s, %s, %s)'
        vals = (userId, pw, userName)
        try:
            self.cursor.execute(sql,vals)
            self.conn.commit()
        except Exception as e:
            print("join 에러")
            print(e)
            return -1

        print(f"{userId} 회원가입 완료")
        return 0

    def login(self, userInfo):
        userId = userInfo['UserId']
        pw = userInfo['Pw']

        sql = 'SELECT USER_ID, PW FROM USER WHERE USER_ID = %s AND PW = %s'
        vals = (userId, pw)

        try:
            self.cursor.execute(sql, vals)
        except Exception as e:
            print("login 에러")
            print(e)

        row = self.cursor.fetchone()
        if row is None:
            return -1
        else:
            return 0
        print(f"{userId} 로그인 성공")

    def add_modelInfo(self, recv_msg):
        userInfo = recv_msg["UserInfo"]
        modelInfo = recv_msg["ModelInfo"]
        model_dir = os.path.join('models',modelInfo["ModelId"])

        sql = 'INSERT INTO MODEL VALUES(%s, %s, %s, %s, %s, %s, %s, %s)'
        vals = (modelInfo["ModelId"], userInfo["UserId"], modelInfo["Classification"],
                modelInfo["Epoch"], model_dir, modelInfo["ImageWidth"], modelInfo["ImageHeight"],
                modelInfo["ColorType"])
        try:
            self.cursor.execute(sql, vals)
            self.conn.commit()
        except Exception as e:
            print("add_modelInfo 에러")
            print(e)
        print("모델정보 DB 추가 완료")

    def add_imageInfo(self, recv_msg):
        modelId = recv_msg["ModelInfo"]["ModelId"]
        for label in recv_msg["Labels"]:
            img_dir = os.path.join('models',modelId,label)
            sql = 'INSERT INTO IMAGE VALUES (%s, %s, %s)'
            vals = (modelId, img_dir, label)

            try:
                self.cursor.execute(sql, vals)
                self.conn.commit()
            except Exception as e:
                print("add_imageInfo 에러")
                print(e)
        print("이미지 정보 DB 추가 완료")

    def select_modelList(self, userId):
        sql = 'SELECT MODEL_ID FROM MODEL WHERE USER_ID = %s'
        vals= (userId,)
        try:
            self.cursor.execute(sql, vals)
        except Exception as e:
            print("select_modelList 에러")
            print(e)
        rows = self.cursor.fetchall()

        result = []
        for row in rows:
            result.append(row[0])
        return result
        print("모델리스트 조회 완료")

    def select_modelInfo(self, modelId):
        sql = "SELECT MODEL_ID, MODEL_DIR, IMAGE_WIDTH, IMAGE_HEIGHT, COLOR_TYPE FROM MODEL WHERE MODEL_ID = %s"
        vals = (modelId,)
        try:
            self.cursor.execute(sql,vals)
        except Exception as e:
            print("select_modelInfo 에러")
            print(e)
        row = self.cursor.fetchone()
        modelInfo = {'ModelId': row[0], 'ModelDir': row[1], 'ImageWidth': row[2], 'ImageHeight': row[3],
                     'ColorType': row[4]}

        sql2 = "SELECT LABEL FROM IMAGE WHERE MODEL_ID = %s"
        try:
            self.cursor.execute(sql2,vals)
        except Exception as e:
            print("select_modelInfo 에러")
            print(e)
        rows = self.cursor.fetchall()
        labels = []
        for row in rows:
            labels.append(row[0])
        modelInfo['Labels'] = labels

        print("모델 정보 조회 완료")
        return modelInfo

# dbc = DBC()
# # res = dbc.select_modelList("LJH")
# # res = dbc.select_modelInfo("4444")
# dbc.add_modelInfo()