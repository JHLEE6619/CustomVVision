import os

class File_handler:
    def makedirs(self,path):
        if not os.path.exists(path):
            os.makedirs(path)
