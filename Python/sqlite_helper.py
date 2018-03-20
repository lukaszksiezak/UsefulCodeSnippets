from sqlalchemy import Column, Integer, Unicode, UnicodeText, String
from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker
from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy import text


class SqliteHelper():
    _session = None
    _db_name = None
    engine = None

    def __init__(self, db_name):
        
        self._db_name = db_name
        self.engine = create_engine(
            "sqlite:///{0}".format(self._db_name), echo=True)


    def _init_session(self):
        Base = declarative_base(bind=self.engine)
        Base.metadata.create_all()
        Session = sessionmaker(bind=self.engine)
        s = Session()
        return s

    def commit_object(self, data_to_commit):
        if(self._db_name is not None):
            session = self._init_session()
            for element in data_to_commit:
                session.add(element)
            session.commit()
            session.close()
        else:
            print("Db name not specified")

    def query_database(self, sql_query):
        result = self.engine.execute(sql_query)
        results = []
        for row in result:
            results.append(row)
        return results
