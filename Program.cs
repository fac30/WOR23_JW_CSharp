// => Inputs
int level = new Random().Next(0, 101);
int roles = new Random().Next(0, 4);

string permission = "";
if (roles > 0)
{
  if (roles == 1)
    permission = "Admin";
  else if (roles == 2)
    permission = "Manager";
  else if (roles >= 3)
    permission = "Admin|Manager";
}

Console.WriteLine($"Level: {level}");
Console.WriteLine($"Permissions: {permission}");


// => Setup
bool isAdmin = permission.Contains("Admin");
bool isManager = permission.Contains("Manager");

bool hasAccess = isAdmin ? true : false;
bool couldAccess = (permission != "" && level >= 20) ? true : false;


// => Assign Tags
string userHigh;

if (isAdmin)
{
  userHigh = level > 55 ? "Super Admin" : "Admin";
}
else if (isManager)
{
  userHigh = "Manager";
  hasAccess = false;
  couldAccess = level >= 20 ? true : false;
}
else
{
  userHigh = "Peasant";
  hasAccess = false;
  couldAccess = false;
}

// => String Builders
string line2;

// ==> Line 1: Salutation Builder
string line1;
string salute;
string punct = ".";

if (userHigh == "Super Admin")
{
  salute = "Hail";
  punct = "!";
}
else if (userHigh == "Admin")
{
  salute = "Welcome";
}
else if (userHigh == "Manager")
{
  salute = "Hello";
}
else
{
  salute = "Yes";
  punct = "?";
}

line1 = $"{salute}, {userHigh}{punct}";

// ==> Line 2: Statement Builder
if (userHigh == "Super Admin")
{
  line2 = "Let me know if I may be of assistance to you.";
}
else if (hasAccess)
{
  line2 = "";
}
else if (couldAccess)
{
  line2 = "Contact an Admin for access.";
}
else 
{
  line2 = "You do not have sufficient privileges.";
}


// => Output
Console.WriteLine($"{line1}");
if (line2 != "")
  Console.WriteLine($"{line2}");

/* ====== Goal ======
  Admin with a level greater than 55
    Welcome, Super Admin user.

  Admin with a level less than or equal to 55
    Welcome, Admin user.

  Manager with a level 20 or greater
    Contact an Admin for access.

  Manager with a level less than 20
    You do not have sufficient privileges.

  Not an Admin or a Manager
    You do not have sufficient privileges.
*/