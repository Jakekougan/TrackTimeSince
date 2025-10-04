class ClockedTime
{
    public string Day;
    public string Hour;
    public string Minute;
    public string Second;

    //All inputs to the constructor must follow this format, dd:hh:mm:ss
    public ClockedTime(string stopwatchTime)
    {
        string[] spans = stopwatchTime.Split(":");



        this.Day = spans[0];
        this.Hour = spans[1];
        this.Minute = spans[2];
        this.Second = spans[3];
    }

    public string toString()
    {
        return this.Day + ":" + this.Hour + ":" + this.Minute + ":" + this.Second;
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

}