import os
from os import listdir
from os.path import isfile, join
import json


class FileHelper():

    @staticmethod
    def get_directory_files(dir_path):
        """List of all the files in given directory (skip directories).
        Arguments: path - string
        Returns: array of strings"""
        return [f for f in listdir(dir_path) if isfile(join(dir_path, f))]

    @staticmethod
    def read_json_file(file_path):
        data_file = open(file_path, 'r')
        data = json.load(data_file)
        data_file.close()
        return data

    @staticmethod
    def delete_if_exists(file_path):
        try:
            os.remove(file_path)
        except OSError:
            pass
