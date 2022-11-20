

# American Express

card_number = “378282246310005”
# MasterCard
# card_number =
    “5555555555554444”# Visa
# card_number = “4222222222222”


//Check(card_number); example

static void Check(string ccNumber)
{
    if (!IsValidNumber(ccNumber))
    {
        return;
    }
    switch (ccNumber.Length)
    {
        case 15:
            Console.WriteLine("American Express");
            break;
        case 16:
            Console.WriteLine(ccNumber.StartsWith("5") ? "MasterCard" : "Visa");
            break;
        case 13:
            Console.WriteLine("Visa");
            break;
    }
}


static bool IsValidNumber(string ccNumber)
{
    var sum = 0;
    var alternate = false;
    for (int i = ccNumber.Length - 1; i >= 0; i--)
    {
        var nx = ccNumber.ToArray();
        var n = int.Parse(nx[i].ToString());

        if (alternate)
        {
            n *= 2;

            if (n > 9)
            {
                n = (n % 10) + 1;
            }
        }
        sum += n;
        alternate = !alternate;
    }
    return (sum % 10 == 0);
}