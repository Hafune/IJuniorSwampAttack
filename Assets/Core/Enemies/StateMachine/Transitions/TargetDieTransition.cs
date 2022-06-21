public class TargetDieTransition : Transition
{
    private void Update()
    {
        NeedTransit = Target == null;
    }
}