using System.Threading;
using System.IO;

class TimeSince
{
    public static void Main(String[] args)
    {
        TimeSince timer = new TimeSince();
        timer.run();


    }

    private string seconds;
    private string minutes;
    private string hours;
    private string days;
    private string time;
    private string filename;

    TimeSince()
    {

        this.filename = "clockedTime.txt";

        try
        {
            string lines = File.ReadAllText(this.filename);
            string[] spans = LoadTime();

            this.days = spans[0];
            this.hours = spans[1];
            this.minutes = spans[2];
            this.seconds = spans[3];

            this.time = this.days + ":" + this.hours + ":" + this.minutes + ":" + this.seconds;
        }

        catch (System.IO.FileNotFoundException)
        {
            this.seconds = "00";
            this.days = "00";
            this.minutes = "00";
            this.hours = "00";
            this.days = "00";
            this.time = this.days + ":" + this.hours + ":" + this.minutes + ":" + this.seconds;
        }



    }

    private string FormatTime(string time)
    {
        int number = int.Parse(time);
        number++;
        if (number < 10)
        {
            time = "0" + number.ToString();
        }

        else
        {
            time = number.ToString();
        }
        return time;
    }

    private void SaveTime(string time)
    {
        File.WriteAllText(this.filename, time);
    }

    private string[] LoadTime()
    {
        string loadedTime = File.ReadAllText(this.filename);
        string[] timeSpans = loadedTime.Split(":");



        return timeSpans;
    }


    public void run()
    {
        while (true)
        {

            this.time = this.days + ":" + this.hours + ":" + this.minutes + ":" + this.seconds;
            SaveTime(this.time);
            Thread.Sleep(1000);

            this.seconds = FormatTime(this.seconds);

            if (int.Parse(this.seconds) > 59)
            {
                this.minutes = FormatTime(this.minutes);
                this.seconds = "00";
            }

            else if (int.Parse(this.minutes) > 59)
            {
                this.hours = FormatTime(this.hours);
                this.minutes = "00";
            }

            else if (int.Parse(this.hours) > 23)
            {
                this.days = FormatTime(this.days);
                this.hours = "00";
            }






        }


    }

}


