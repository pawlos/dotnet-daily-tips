# 018 - Debugger settings #

During debugging, one of the techniques is using breakpoints. But breakpoints are not the only way to interact with the program.

If we do not want to break the program execution (sometimes stopping the program is not wanted) we can transform it to Tracepoint and print a message, when the code is passing though it. If our breakpoint would be hit multiple times and we do not want to restart execution after each breakpoint hit, we can use the Hit count property to specify how many hits should be passed through before the program should stop. Another option is to set up a condition that would be evaluated each time - be aware that it might impact the programs performance. We can also enable one breakpoint when another one is hit - useful if there's a dependency between the places we want to break at.
Last but not least, there's also an option to remove the breakpoint once hit.

I really like the dialog for breakpoint settings in Rider but VS has all the same settings too.


![rider](rider.jpg)
![vs](vs.jpg)