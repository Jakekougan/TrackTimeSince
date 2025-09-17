using System.Threading;

class TimeSince
{
     public static void Main(String[] args)
    {
        TimeSince timer = new TimeSince();
        timer.run();


    }
    private int seconds;
    private int minutes;
    private int hours;
    private int days;
    private string time;

    TimeSince()
    {
        this.seconds = 0;
        this.days = 0;
        this.minutes = 0;
        this.hours = 0;
        this.days = 0;
        this.time = "0" + this.days + ":" + "0" + this.hours + ":" + "0" + this.minutes + ":" + "0" + this.seconds;

    }

    private string Format()
    {

    }

    public void run()
    {
        while (this.minutes != 2)
        {
            if (this.seconds < 10)
            {
                this.time = this.days + ":" + this.hours + ":" + this.minutes + ":" + "0" + this.seconds;
            }

            else
            {
                this.time = this.days + ":" + this.hours + ":" + this.minutes + ":" + this.seconds;
            }

            Console.WriteLine(this.time);
            this.seconds++;
            Thread.Sleep(1000);



            if (this.seconds > 59)
            {
                this.seconds = 0;
                this.minutes++;
            }

            else if (this.minutes > 59)
            {
                this.minutes = 0;
                this.hours++;

            }

            else if (this.hours > 23)
            {
                this.hours = 0;
                this.days++;
            }
        }


    }

}


