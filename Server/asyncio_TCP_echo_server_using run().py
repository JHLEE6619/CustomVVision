import asyncio
import orjson
import DBC
from enum import IntEnum, auto

# while문이 없어도 계속해서 read하는 비동기 멀티스레드 서버

class Msg(IntEnum):
    JOIN = 0
    LOGIN = auto()
    CREATE_MODEL = auto()
    SHOW_MODEL_LIST = auto()
    TEST_MODEL = auto()
    DOWNLOAD_MODEL = auto()

#이벤트 콜백을 정의하는 프로토콜 클래스
class EchoServerProtocol(asyncio.Protocol):
    
    #연결이 성공하면 호출되는 콜백
    #transport는 연결 소켓을 나타내고 이벤트 루프에서 전달된다
    def connection_made(self, transport):
        peername = transport.get_extra_info('peername')
        print('Connection from {}'.format(peername))
        self.transport = transport #소켓

    #데이터를 수신하면 호출되는 콜백
    #data(수신된 데이터)는 이벤트 루프에서 전달된다
    def data_received(self, data):
        message = data.decode()
        print('Data received: {!r}'.format(message))
        msg = orjson.loads(message)  # 메세지 받을때 딕셔너리로 역직렬화
        self.handler(msg)
        # print('Send: {!r}'.format(message))
        # self.transport.write(data) #데이터 송신
        #
        # print('Close the client socket')
        # self.transport.close() #연속 서비스를 원하면 이 문장 삭제

    def handler(self, msg):
        dbc = DBC.DBC()
        msgId = msg["msgId"]
        match msgId:
            case Msg.JOIN:
                dbc.join(msg["UserInfo"])
                return
            case Msg.LOGIN:
                dbc.login(msg["userInfo"])
                return
            case Msg.CREATE_MODEL:
                dbc.add_modelInfo(msg)
                return
            case Msg.SHOW_MODEL_LIST:
                dbc.select_modelList(msg["userInfo"]["userId"])
            case Msg.TEST_MODEL:
                dbc.select_modelDir(msg["modelInfo"]["modelId"])
                # 파일 수신 함수
                # 테스트 하는 함수
                return
            case Msg.DOWNLOAD_MODEL:
                dbc.select_modelList(msg["userInfo"]["userId"])
                # 파일 전송 함수
                return






async def main():
    # 저수준 API를 사용하기 위해 현재 이벤트 루프를 가져온다
    loop = asyncio.get_running_loop()

    #서버 객체 생성 및 실행 예약
    server = await loop.create_server(
        lambda: EchoServerProtocol(), '127.0.0.1', 10000)

    #서버 실행
    async with server:
        await server.serve_forever()

asyncio.run(main())