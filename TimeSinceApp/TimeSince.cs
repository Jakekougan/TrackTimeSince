using System.Threading;
using System.IO;
using System;

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
    private string date;

    TimeSince()
    {

        this.filename = "clockedTime.txt";
        //Handles Cases where a running clock is detected
        try
        {
            string[] lines = File.ReadAllLines(this.filename);

            this.date = lines[0];
            string time = lines[1];

            string[] spans = time.Split(":");



            this.days = spans[0];
            this.hours = spans[1];
            this.minutes = spans[2];
            this.seconds = spans[3];


            this.time = this.days + ":" + this.hours + ":" + this.minutes + ":" + this.seconds;

            this.tearDown();

            string currTime = this.subtractTime();

            ClockedTime correctCurr = new ClockedTime(currTime);

            this.days = correctCurr.Day;
            this.hours = correctCurr.Hour;
            this.minutes = correctCurr.Minute;
            this.seconds = correctCurr.Second;

            this.time = this.days + ":" + this.hours + ":" + this.minutes + ":" + this.seconds;

        }

        //If not file is found, start the clock at 0
        catch (System.IO.FileNotFoundException)
        {
            this.seconds = "00";
            this.days = "00";
            this.minutes = "00";
            this.hours = "00";
            this.days = "00";
            this.time = this.days + ":" + this.hours + ":" + this.minutes + ":" + this.seconds;

            DateTime now = DateTime.Now;

            this.date = now.ToString();
        }



    }

    public string subtractTime()
    {
        TimeSpan elapsed = DateTime.Now - DateTime.Parse(this.date);

        string day = FormatTime(elapsed.Days.ToString());
        string hr = FormatTime(elapsed.Hours.ToString());
        string min = FormatTime(elapsed.Minutes.ToString());
        string seconds = FormatTime(elapsed.Seconds.ToString());

        string newTime = day + ":" + hr + ":" + min + ":" + seconds;

        return newTime;

    }



    private static string FormatTime(string time)
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
        File.WriteAllLines(this.filename, [this.date, time]);
    }

    private void tearDown()
    {
        File.Delete(this.filename);
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
