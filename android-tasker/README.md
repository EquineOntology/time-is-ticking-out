Tasker ([Website](https://tasker.dinglisch.net/index.html)|[App](https://play.google.com/store/apps/details?id=net.dinglisch.android.taskerm&hl=en)) is an automation app for Android. In the heap of stuff it can do are included notifications, which are an awesome way to display how long you still have to live.

### Installation instructions
To set up Time Is Ticking Out on your Android phone:

1. Download [time-is-ticking-out.js](https://github.com/HHErebus/time-is-ticking-out/blob/develop/android-tasker/time-is-ticking-out.js) to the Tasker folder in your phone<sup>1</sup>

2. Download [time-is-ticking-out.xml](https://github.com/HHErebus/time-is-ticking-out/blob/develop/android-tasker/time-is-ticking-out.xml) to wherever you want

3. Import the profile (`time-is-ticking-out.xml`), which you can do following [this guide](https://almost-a-technocrat.blogspot.com.es/2013/04/how-to-import-tasker-projects-profiles.html)

4. In Tasker, change Actions 2 and 3 to whatever you wish, provided that
    * Action 2, `VARIABLE SET %DATE_OF_BIRTH`, is `YYYY-MM-DD`, and
    * Action 3, `VARIABLE SET %LIFE_EXPECTANCY`, is a number.

And that's it! You can run it to see the notification pop up, and get rid of the `IF` action at the beginning, which I inserted to lessen the battery charge hit that having a task continuously running in the background causes.

Cheers!

---

<sup>1</sup>: it might also work if you have Tasker installed in the SD card and download the file in the Tasker folder _there_, but it's untested.