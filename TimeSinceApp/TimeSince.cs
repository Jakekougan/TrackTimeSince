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
        this.seconds = "00";
        this.days = "00";
        this.minutes = "00";
        this.hours = "00";
        this.days = "00";
        this.filename = "clockedTime.txt";


        if (File.ReadAllText("clockedTime.txt") != "")
        {
            this.time = LoadTime();
        }

        else
        {
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

    private string LoadTime()
    {
            string loadedTime = File.ReadAllText(this.filename);



        return loadedTime;
    }


    public void run()
    {
        while (int.Parse(this.minutes) <= 2)
        {

            this.time = this.days + ":" + this.hours + ":" + this.minutes + ":" + this.seconds;
            Console.WriteLine(this.time);
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

        SaveTime(this.time);


    }

}


