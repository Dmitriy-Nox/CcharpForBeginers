using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuntTheWumpus
{
    public class Room<T>
    {
        public Room(int capacity)
        {
            objectsInRoom = new T[capacity];
        }

        private T[] objectsInRoom;
        public T[] ObjectsInRoom => objectsInRoom;

        public int Count { get; set; }

        public void Place(T gameObject)
        {
            for (int i = 0; i < objectsInRoom.Length; i++)
            {
                if (objectsInRoom[i] == null)
                {
                    objectsInRoom[i] = gameObject;
                    Count++;
                    break;
                }
                    
            }
        }

        public T GetFromIndex(int index)
        {
            return objectsInRoom[index];
        }

    }

    public class Game
    {
        public void Start()
        {
            Room<string> roomString = new Room<string>(10);
            roomString.Place("Room1");
            roomString.Place("Room2");

            for (int i = 0; i < roomString.Count; i++)
            {
                Console.WriteLine(roomString.GetFromIndex(i));
            }


            Room<Player> roomPlayer = new Room<Player>(10);

            roomPlayer.Place(new Player(new Coordinates(1, 1)));
            roomPlayer.Place(new Player(new Coordinates(1, 2)));

            for (int i = 0; i < roomPlayer.Count; i++)
            {
                var x = roomPlayer.GetFromIndex(i).Coordinates.X;
                var y = roomPlayer.GetFromIndex(i).Coordinates.Y;
                Console.WriteLine(x+" "+y);
            }
        }
    }

    public class Player
    {
        public Player(Coordinates coordinates)
        {
            Coordinates = coordinates;
        }
        public Coordinates Coordinates;
    }

    public class Coordinates
    {

        public Coordinates(int x,int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; set; }

        public int Y { get; set; }

    }

}
