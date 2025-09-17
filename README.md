# ⏱ TimeSince

A simple C# console application that simulates a timer, displaying the elapsed time in the format `days:hours:minutes:seconds`. The timer runs until 2 minutes have passed.

## 🧠 Overview

This program:
- Initializes a timer starting from `0:0:0:0`
- Updates the time every second
- Displays the formatted time in the console
- Stops execution after 2 minutes

## 📦 Features

- Real-time second-by-second updates
- Time formatting with leading zeros for seconds < 10
- Automatic rollover from seconds → minutes → hours → days

## 🚀 How to Run

1. Make sure you have [.NET SDK](https://dotnet.microsoft.com/download) installed.
2. Save the code in a file named `TimeSince.cs`.
3. Open a terminal and navigate to the file's directory.
4. Compile and run:

   ```bash
   csc TimeSince.cs
   TimeSince.exe
