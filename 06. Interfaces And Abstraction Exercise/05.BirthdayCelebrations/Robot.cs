using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
{
    public class Robot:IRobot
    {
        private string model;
        private string id;

        public Robot(string model,string id)
        {
            Model = model;
            Id = id;
        }
        public string Model
        {
            get { return model; }
            set
            {
                model = value;
            }
        }
        public string Id
        {
            get { return id; }
            set
            {
                id = value;
            }
        }
    }
}
