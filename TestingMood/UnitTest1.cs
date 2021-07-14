using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mood_Analyser;

namespace TestingMood
{
    [TestClass]
    public class UnitTest1
    {
        MoodAnalyser setmood;
        MoodAnalyser setmood1;
        MoodAnalyser setNull;
        MoodAnalyser setEmpty;

        [TestInitialize]
        public void SetUp()
        {
            string[] message = { "i", "am", "in", "sad", "mood" };
            setmood = new MoodAnalyser(message);
            string[] message1 = { "i", "am", "in", "any", "mood" };
            setmood1 = new MoodAnalyser(message1);
            string[] message2 = null;
            setNull = new MoodAnalyser(message2);
            string[] message3 = { "" };
            setEmpty = new MoodAnalyser(message3);

        }
        /// <summary>
        /// TC 1.1
        /// </summary>
        //To check if user is sad
        [TestMethod]
        [TestCategory("Sad")]
        public void Given_SadMood_return_Sad()
        {
            string actual = setmood.ReturnMessage();
            string expected = "Sad";
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// TC 1.2
        /// </summary>
        //To check if user is happy
        [TestMethod]
        [TestCategory("Happy")]
        public void Given_AnyMood_return_Happy()
        {
            string actual = setmood1.ReturnMessage();
            string expected = "Happy";
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// TC 2.1
        /// </summary>
        //Null reference Exception
        [TestMethod]
        [TestCategory("NullReferenceException")]
        public void Given_NullArgument_return_Happy()
        {
            string actual = setNull.ReturnMessage();
            string expected = "Happy";
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// TC 3.1
        /// </summary>
        [TestMethod]
        [TestCategory("CustomizedException")]
        public void Given_NullMessage_using_CustomizeException_Return_NullException()
        {
            try
            {
                setNull.ReturnMessage();

            }
            catch (CustomizeException ex)
            {
                string expected = "Mood should not be Null";
                Assert.AreEqual(expected, ex.Message);
            }
        }
        /// <summary>
        /// TC 3.2
        /// </summary>
        [TestMethod]
        [TestCategory("CustomizedException")]
        public void Given_EmptyMood_using_CustomizeException_Return_Empty()
        {
            try
            {
                setEmpty.ReturnMessage();

            }
            catch (CustomizeException ex)
            {
                string expected = "Mood should not be Empty";
                Assert.AreEqual(expected, ex.Message);
            }
        }
       
    }
}
