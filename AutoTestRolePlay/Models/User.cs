using System;
using System.Threading;
using WebTest.Helpers;

namespace WebTest.Models
{
    public class User
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public bool Mailing { get; set; }
        public Game Game { get; set; }
        public Session Session { get; set; }
        public Plot Plot { get; set; }
        
        public static User GetRandomUser()
        {
            return new User()
            {
                Firstname = TextHelper.GetRandomWord(10),
                LastName = TextHelper.GetRandomWord(10),
                Email = TextHelper.GetRandomWord(10) + "@" + TextHelper.GetRandomWord(6) + "." + TextHelper.GetRandomWordWithoutNumbers(2),
                Phone = "8" + TextHelper.GetRandomNumbers(10),
                Message = TextHelper.GetRandomWord(20),
                Mailing = true,
                Game = Game.Fantazy,
                Plot = Plot.Plot1,
                Session = Session.Session1
            };
        }
        
        public string GetGame()
        {
            switch (this.Game)
            {
                case Game.Fantazy:
                    return "Эсвас";
                case Game.Wasteland:
                    return "Пустоши";
                case Game.STALKER:
                    return "STALKER";
            }
            return null;
        }
        
        public string GetSession()
        {
            switch (this.Session)
            {
                case Session.Session1:
                    return "Сессия 1";
                case Session.Session2:
                    return "Сессия 2";
                case Session.Session3:
                    return "Сессия 3";
            }
            return null;
        }
        
        public string GetPlot()
        {
            switch (this.Plot)
            {
                case Plot.Plot1:
                    return "Сюжет 1";
                case Plot.Plot2:
                    return "Сюжет 2";
                case Plot.Plot3:
                    return "Сюжет 3";
            }
            return null;
        }
        
    }

    public enum Game
    {
        Fantazy,
        Wasteland,
        STALKER
    }
    
    public enum Session
    {
        Session1,
        Session2,
        Session3
    }
    
    public enum Plot
    {
        Plot1,
        Plot2,
        Plot3
    }
}