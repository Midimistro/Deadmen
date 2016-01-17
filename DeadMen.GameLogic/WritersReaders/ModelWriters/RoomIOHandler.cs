using DeadMen.API.Models;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace DeadMen.GameLogic.WritersReaders
{
    public class RoomIOHandler
    {
        private IWriter _writer;
        private IReader _reader;
        private int templateRooms;

        public RoomIOHandler(IWriter writer, IReader reader)
        {
            _writer = writer;
            _reader = reader;
        }

        public void SaveTemplateRoom(Room TemplateRoom)
        {
            _writer.Write(SerializeToXML(TemplateRoom), _writer.DataFilePath(string.Format("TemplateRoom_{0}",templateRooms.ToString())));
            templateRooms++;
        }

        public void SaveRecordRoom(Room RecordedRoom)
        {
            _writer.Write(SerializeToXML(RecordedRoom), _writer.DataFilePath(string.Format("RecordedRoom_{0}", templateRooms.ToString())));
        }

        public List<Room> LoadRecordedRooms()
        {
            var allRooms = new List<Room>();

            while (_reader.FileExists(string.Format("RecordedRoom_{0}", allRooms.Count)))
            {
                allRooms.Add(SerializeFromXML(_reader.Read(string.Format("RecordedRoom_{0}", allRooms.Count))));
            }

            return allRooms;
        }

        private string SerializeToXML(Room room)
        {
            using (var stringWriter = new StringWriter())
            {
                var outputStringBuilder = new XmlSerializer(typeof(Room));
                outputStringBuilder.Serialize(stringWriter, this);

                return stringWriter.ToString();
            }
        }

        private Room SerializeFromXML(string XMLString)
        {
            using (var stringReader = new StringReader(XMLString))
            {
                var inputObjectBuilder = new XmlSerializer(typeof(Room));
                var room = (Room)inputObjectBuilder.Deserialize(stringReader);

                return room;
            }

        }
    }
}
