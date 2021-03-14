using System;


namespace TasksLibrary {

    public class Task : IComparable<Task> {
        // Static fields.
        static private TimeSpan oldTaskRemainsTime; 
        static private int maxDescriptionSize;

        static Task() {
            oldTaskRemainsTime = new TimeSpan(24,0,0);
            maxDescriptionSize = 200;
        }

        // Class logic.
        private bool isDone;
        private DateTime doneTime;
        private string _name;
        private string _description;
        private DateTime _deadline;
        public string Name {get => _name; set => _name = value;}
        public string Description {
            get => _description; 
            set {
                if (value.Length < maxDescriptionSize) 
                    _description = value;
                else
                {
                    throw new Exception("Too much symbols in description!");
                } 
            } 
        }
        public bool IsOutdated {
            get {
                return (DateTime.Now - doneTime) > oldTaskRemainsTime && isDone;
            }
        }

        public DateTime Deadline {
            get => _deadline;
            set {
                if (value < DateTime.Now)
                    throw new Exception("Oops, you've already missed your deadline!");
                else
                    _deadline = value; 
            }
        }
        public Task (string name, string description, DateTime deadline ) {
            Name = name;
            Description = description;
            Deadline = deadline; 
        }

        public void Check() {
            isDone = !isDone;
            if (isDone) doneTime = DateTime.Now;
        }

        public void Edit(string name) {
            Name = name;
        }
        public void Edit(string name, string description) {
            Name = name;
            Description = description;
        }
        public void Edit(string name, string description, DateTime deadline) {
            Name = name;
            Description = description;
            Deadline = deadline;
        }

        public override string ToString()
        {
            string state = isDone ? "done" : "not done";
            return $"{Name} => {Description} (until {Deadline}) : is {state}.";
            //return base.ToString() + ;
        }

        public override bool Equals(object obj)
        {
            Task tempTask = obj as Task;
            if (tempTask == null) 
                return false;
            else            
                return base.Equals((Task)obj) && tempTask.Name == Name && tempTask.Description == tempTask.Description;
        }

        public override int GetHashCode()
        {
            return (Name.GetHashCode() >> (32 - (byte)(Description.GetHashCode()))) ^ Deadline.GetHashCode() ;
        }

        int IComparable<Task>.CompareTo(Task other) {
            if (other != null) {
                if (Deadline < other.Deadline) 
                    return -1;
                if (Deadline > other.Deadline)
                    return 1;
                else
                    return 0;
            }
            else
                throw new ArgumentException("Parameter is not a Task!");
        }

    }

}