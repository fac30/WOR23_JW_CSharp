# Expiration Discount Calculator

```csharp
Random random = new Random();
int daysUntilExpiration = random.Next(12);
int discountPercentage = 0;

string messageExpire = "";
string messageDiscount = "";

if (daysUntilExpiration <= 10)
{
	if (daysUntilExpiration <= 0)
	{
		messageExpire = "Your subscription has expired.";
	}
	else if (daysUntilExpiration == 1)
	{
		messageExpire = "Your subscription expires within a day!";
	}
	else if (daysUntilExpiration <= 5)
	{
		messageExpire = $"Your subscription expires in {daysUntilExpiration} days.";
	}
	else if (daysUntilExpiration <= 10)
	{
		messageExpire = "Your subscription will expire soon. Renew now!";
	}
	else
	{
		messageExpire = $"Error: {daysUntilExpiration} Days Not Caught";
	}
}

if (daysUntilExpiration >= 1 && daysUntilExpiration <= 5)
{
	if (daysUntilExpiration == 1)
	{
		discountPercentage = 20;
	}
	else
	{
		discountPercentage = 10;
	}
	messageDiscount = $"\nRenew now and save {discountPercentage}%!";
}

string message = $"{messageExpire}{messageDiscount}";
Console.WriteLine(message);
```
