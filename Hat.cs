namespace Quest
{
    public class Hat
    {
        public int ShininessLevel { get; set; }
        public string ShininessDescription
        {
            get
            {
                // ok to use if...else here because it will capture the value accordingly, will use inclusive upper bounds
                if (ShininessLevel < 2)
                {
                    return "dull";
                }
                else if (ShininessLevel <= 5)
                {
                    return "noticeable";
                }
                else if (ShininessLevel <= 9)
                {
                    return "bright";
                }
                else // ShininessLevel > 9
                {
                    return "blinding";
                }
            }
        }
    }
}
