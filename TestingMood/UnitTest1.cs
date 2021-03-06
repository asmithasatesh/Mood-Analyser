using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mood_Analyser;
using System;

namespace TestingMood
{
    [TestClass]
    public class UnitTest1
    {
        MoodAnalyser setmood;
        MoodAnalyser setmoodAny;
        MoodAnalyser setNull;
        MoodAnalyser setEmpty;
        MoodAnalyserFactory moodAnalyserFactory;

        [TestInitialize]
        public void SetUp()
        {
            string[] sadmessage = { "i", "am", "in", "sad", "mood" };
            setmood = new MoodAnalyser(sadmessage);
            string[] happymessage = { "i", "am", "in", "any", "mood" };
            setmoodAny = new MoodAnalyser(happymessage);
            string[] message2 = null;
            setNull = new MoodAnalyser(message2);
            string[] message3 = { "" };
            setEmpty = new MoodAnalyser(message3);
            moodAnalyserFactory = new MoodAnalyserFactory();

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
            string actual = setmoodAny.ReturnMessage();
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
        /// <summary>
        /// TC 4.1
        /// </summary>
        [TestMethod]
        [TestCategory("Using Reflection")]
        public void Given_MoodAnalyser_using_Reflection_Return_defaultParameter()
        {
            MoodAnalyser expexted = new MoodAnalyser();
            object constructor;

            constructor = moodAnalyserFactory.CreatingObjectWithMethod("Mood_Analyser.MoodAnalyser", "MoodAnalyser");
            expexted.Equals(constructor);
        }
        /// <summary>
        /// TC 4.2
        /// </summary>
        [TestMethod]
        [TestCategory("Using Reflection")]
        public void Given_InvalidConstructor_using_Reflection_Return_CustomisedException()
        {
            string expected = "Class does not have such Constructor";
            object constructor;
            try
            {
                constructor = moodAnalyserFactory.CreatingObjectWithMethod("Mood_Analyser.MoodAnalyser", "MoodAnaly");
            }
            catch(CustomizeException actual)
            {
                Assert.AreEqual(expected, actual.Message);
            }
        }
        /// <summary>
        /// TC 4.3
        /// </summary>
        [TestMethod]
        [TestCategory("Using Reflection")]
        public void Given_InvalidClass_using_Reflection_Return_CustomisedException()
        {
            string expected = "Class does not exist";
            object constructor;
            try
            {
                constructor = moodAnalyserFactory.CreatingObjectWithMethod("Mood_Analyser.MoodAnaly", "MoodAnaly");
            }
            catch (CustomizeException actual)
            {
                Assert.AreEqual(expected, actual.Message);
            }
        }
        /// <summary>
        /// TC 5.1
        /// </summary>
        [TestMethod]
        [TestCategory("Using Parameterised Reflection")]
        public void Given_MoodAnalyserAny_using_Reflection_Return_Parameterisedobject()
        {
            string[] happymessage = { "i", "am", "in", "any", "mood" };
            MoodAnalyser expected = setmoodAny;
            object constructor;
            try
            {
                constructor = moodAnalyserFactory.CreatingParameterisedObjectWithMethod("Mood_Analyser.MoodAnalyser", "MoodAnalyser", happymessage);
                expected.Equals(constructor);
            }
            catch (CustomizeException actual)
            {
                Assert.AreEqual(expected, actual.Message);
            }
        }
        /// <summary>
        /// TC 5.2
        /// </summary>
        [TestMethod]
        [TestCategory("Using Parameterised Reflection")]
        public void Given_InvalidconstructorMoodAnalyser_using_Reflection_Return_Parameterisedobject()
        {
            string[] happymessage = { "i", "am", "in", "any", "mood" };
            string expected = "Class does not exist";
            object constructor;
            try
            {
                constructor = moodAnalyserFactory.CreatingParameterisedObjectWithMethod("Mood_Analyser.MoodAnalyser", "MoodAnalye", happymessage);
                expected.Equals(constructor);
            }
            catch (CustomizeException actual)
            {
                Assert.AreEqual(expected, actual.Message);
            }
        }
        /// <summary>
        /// TC 5.3
        /// </summary>
        [TestMethod]
        [TestCategory("Using Parameterised Reflection")]
        public void Given_InvalidClass_MoodAnalyser_using_Reflection_Return_Parameterisedobject()
        {
            string[] happymessage = { "i", "am", "in", "any", "mood" };
            string expected = "Class does not have such Constructor";
            object constructor;
            try
            {
                constructor = moodAnalyserFactory.CreatingParameterisedObjectWithMethod("Mood_Analyser.MoodAna", "MoodAnalyser", happymessage);
                expected.Equals(constructor);
            }
            catch (CustomizeException actual)
            {
                Assert.AreEqual(expected, actual.Message);
            }
        }
        /// <summary>
        /// TC 6.1
        /// </summary>
        [TestMethod]
        [TestCategory("Invoke Method")]
        public void Given_SadMessage_should_return_Sad()
        {
            string[] sadmessage = { "i", "am", "in", "sad", "mood" };
            string expected = "Sad";
            string actual = moodAnalyserFactory.InvokeMethod("ReturnMessage", sadmessage);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// TC 6.2
        /// </summary>
        [TestMethod]
        [TestCategory("Invoke Method")]
        public void Given_Any_Message_should_return_Sad()
        {
            string[] happymessage = { "i", "am", "in", "any", "mood" };
            string expected = "Happy";
            string actual = moodAnalyserFactory.InvokeMethod("ReturnMessage", happymessage);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// TC 6.3
        /// </summary>
        [TestMethod]
        [TestCategory("Invoke Method")]
        public void Given_Happy_Message_should_return_Sad()
        {
            string[] happymessage = { "i", "am", "in", "happy", "mood" };
            string expected = "Happy";
            string actual = moodAnalyserFactory.InvokeMethod("ReturnMessage", happymessage);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// TC 7.1
        /// </summary>
        [TestMethod]
        [TestCategory("Set Field Value")]
        public void Given_FieldName_Return_Message()
        {
            string[] happymessage = { "i", "am", "in", "happy", "mood" };
            string[] expected = happymessage;
            string[] actual = moodAnalyserFactory.SetFieldValue("message", happymessage);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// TC 7.2
        /// </summary>
        [TestMethod]
        [TestCategory("Set Field Value")]
        public void Given_Invalid_FieldName_Return_Error_Message()
        {
            try
            {
                string[] happymessage = { "i", "am", "in", "happy", "mood" };
                string[] actual = moodAnalyserFactory.SetFieldValue("messagsWrong", happymessage);
            }
            catch(CustomizeException actual)
            {
                string expected = "No such field found";
                Assert.AreEqual(expected, actual.Message);
            }

        }
        /// <summary>
        /// TC 7.3
        /// </summary>
        [TestMethod]
        [TestCategory("Set Field Value")]
        public void Given_Empty_Return_Error_Message()
        {
            try
            {
                string[] happymessage = {""};
                string[] actual = moodAnalyserFactory.SetFieldValue("message", happymessage);
            }
            catch (CustomizeException actual)
            {
                string expected = "Message is empty";
                Assert.AreEqual(expected, actual.Message);
            }

        }
    }
}
