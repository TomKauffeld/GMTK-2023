using System.Collections;

public class Level01 : MyLevel
{

    public override IEnumerator LevelLayout()
    {
        yield return ShowMessage("Welcome to our game :)");
        yield return ShowMessage("The goal is to get the character to the end of the level");
        yield return ShowMessage("This is possible by rotating the level using the arrow keys");


        yield return WaitForEnd();

        if (Win)
            yield return ShowMessage("You finished the level :)", evenIfFinished: true);
        else
            yield return ShowMessage("The character didn't get to the end :(", evenIfFinished: true);
    }
}
