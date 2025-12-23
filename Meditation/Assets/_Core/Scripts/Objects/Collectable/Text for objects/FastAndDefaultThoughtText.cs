namespace _Core.Scripts.Objects.Collectable.Text_for_objects
{
    public class FastAndDefaultThoughtText : ThoughtTextGeneral
    {
        protected override void RandomText(int randomIndex)
        {
            switch (randomIndex)
            {
                case 0:
                    _thoughtText.text = _thoughtTextData.thoughtTextOne;
                    break;
                case 1:
                    _thoughtText.text = _thoughtTextData.thoughtTextTwo;
                    break;
                case 2:
                    _thoughtText.text = _thoughtTextData.thoughtTextThree;
                    break;
            }
        }
    }
}
