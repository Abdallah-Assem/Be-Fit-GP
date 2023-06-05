using BeFit_API.Model;

namespace BeFit_API.Methods
{
    public class CalcMacros
    {
        public void Calculate(UserMacros userMacros) 
        {
            //Calculate BMR (Mifflin-St Jeor)
            double BMR = 0;
            double TDEE = 0;

            if (userMacros.Gender == "Male")
            {
                BMR = (double)(5 + (10 * userMacros.Weight) + (6.25 * userMacros.Height) - (5 * userMacros.Age));
            }
            else
            {
                BMR = (double)((10 * userMacros.Weight) + (6.25 * userMacros.Height) - (5 * userMacros.Age) - 161);
            }
            //Calculate TDEE
            if (userMacros.ActivityLevel == "Sedentary") { TDEE = (double)(BMR * 1.2); }
            else if (userMacros.ActivityLevel == "Lightly") { TDEE = (double)(BMR * 1.375); }
            else if (userMacros.ActivityLevel == "Moderately") { TDEE = (double)(BMR * 1.55); }
            else if (userMacros.ActivityLevel == "Very") { TDEE = (double)(BMR * 1.725); }
            else if (userMacros.ActivityLevel == "Extra") { TDEE = (double)(BMR * 1.9); }
            //Calculate Daily Calories
            if (userMacros.Goal == "Maintain") { userMacros.DailyCalories = Math.Ceiling(TDEE); }
            else if (userMacros.Goal == "Lose") { userMacros.DailyCalories = Math.Ceiling(TDEE - 300); }
            else { userMacros.DailyCalories = Math.Ceiling(TDEE + 300); }
            //Diseases Effect 
            //Diabetes affect by 20%
            if (userMacros.Disease == "Diabetes") { userMacros.DailyCalories = Math.Ceiling(userMacros.DailyCalories * 0.80); }
            //Blood Pressure affect by 8%
            else if (userMacros.Disease == "Blood Pressure") { userMacros.DailyCalories = Math.Ceiling(userMacros.DailyCalories * 0.92); }
            //Cholesterol affect by 17%
            else if (userMacros.Disease == "Cholesterol") { userMacros.DailyCalories = Math.Ceiling(userMacros.DailyCalories * 0.83); }

            //Calculate Daily Protein
            if (userMacros.ActivityLevel == "Sedentary" || userMacros.ActivityLevel == "Lightly") { userMacros.DailyProtein = Math.Ceiling((double)(userMacros.Weight * 0.8)); }
            else if (userMacros.ActivityLevel == "Moderately") { userMacros.DailyProtein = Math.Ceiling((double)(userMacros.Weight * 1.2)); }
            else if (userMacros.ActivityLevel == "Very") { userMacros.DailyProtein = Math.Ceiling((double)(userMacros.Weight * 1.5)); }
            else if (userMacros.ActivityLevel == "Extra") { userMacros.DailyProtein = Math.Ceiling((double)(userMacros.Weight * 2.0)); }
            //Calculate Daily Fats
            userMacros.DailyFats = Math.Ceiling(((double)((userMacros.DailyCalories * 0.3) / 9)));
            //Calculate Daily Carbs
            userMacros.DailyCarbs = Math.Ceiling(((double)((userMacros.DailyCalories * 0.5) / 4)));
            
        }
    }
}
