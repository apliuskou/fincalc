using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinCalc
{
    //Почему в functions and tests мы сделали аналогичный класс static'ом? 
    public static class EstimateIncomeAndFees
    {
        //Пока не используем сложные проценты
        //??если класс static, то он заставляет все переменные внутри себя делать const?
        //??и оно заставляет сразу переменные объявлять и приваивать им значения

        
        const double rateOfReturn = 0.15; //Пока объявим фиксированный уровень доходности в 15% 
        const double minimalRateOfReturn = 0.10; //и сочтём успехом доходность более 10% годовых

        //??Попытался присвоить ранее объявленным переменным значения. Облом! см.ниже.
        //??Пришлось 4 строки ниже закоментить, ибо красным подчёркивает
        /*successFee = 0.2; 
        fixedManagementFee = 500; 
        persentManagementFee = 0.02; 
        successFee = 0.2; */


        public static decimal CalculateManagerialFees(double amountInvested, double investmentPeriodInYears)
        {
            //Вознаграждение управляющего инвестициями составит 2% от инвестированной суммы, но не менее USD 999.
            double fixedManagementFee = 999;

            double persentManagementFee = 0.02;
            //Success Fee (плата за успех) составит 20% от доходности свыше 10%
            double successFee = 0.2;
            double levelOfSuccess = 0.1;

            //Считаем стандартную стоимость услуг инвесткомпании
            persentManagementFee = persentManagementFee * (amountInvested *1000* investmentPeriodInYears);


            if (persentManagementFee < fixedManagementFee)//если 2% от управляемой суммы составят менее 999 долларов, то...
            { persentManagementFee = fixedManagementFee; }//вознаграждение инвестиционной компании составит 999 долларов
            else { persentManagementFee = persentManagementFee; }//иначе мы берём значение persentManagementFe в предыдущем выражении

            //Считаем Success Fee
            successFee = successFee * (rateOfReturn - levelOfSuccess) * amountInvested*1000;


            double managementFee = persentManagementFee +successFee;

            decimal _managementFee = Convert.ToDecimal(managementFee);

            return _managementFee;
        }


        public static decimal CalculateIncome(double amountInvested, double investmentPeriodInYears)
        {//Варварство, но домножил на 1000 вручную, иначе неверный income выходит. И НЕ ПОМОГЛО!
        double income = amountInvested*1000*investmentPeriodInYears*rateOfReturn;
        decimal _income = Convert.ToDecimal(income);

        return _income;

        }

        }
    }
