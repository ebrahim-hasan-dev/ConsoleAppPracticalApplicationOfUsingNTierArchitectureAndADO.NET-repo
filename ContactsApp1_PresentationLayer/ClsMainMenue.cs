using System;
using System.Data;
using ContactsApp_ModulesLayer;
using ContactsApp_BusinessLayer;



namespace ContactsApp1_PresentationLayer
{
    public class ClsMainMenue
    {
        static void GoBack()
        {
            Console.WriteLine("\nPress Any Key To Go Back.");
            Console.ReadKey();
        }

        static void ShowMainMenue()
        {
            Console.WriteLine("\n\n==========================\n");
            Console.WriteLine("Main Menue:\n");
            Console.WriteLine("1-  Add New Contact.");
            Console.WriteLine("2-  Update Contact.");
            Console.WriteLine("3-  Delete Contact.");
            Console.WriteLine("4-  Find Contact.");
            Console.WriteLine("5-  Show All Contacts.");
            Console.WriteLine("6-  Is Contact Exist.");
            Console.WriteLine("7-  Find Country.");
            Console.WriteLine("8-  Is Country Exist.");
            Console.WriteLine("9-  Add New Country.");
            Console.WriteLine("10- Show All Countries.");
            Console.WriteLine("11- Update Country.");
            Console.WriteLine("12- Exit.\n");
            Console.WriteLine("==========================\n");
        }

        static void FillContact(ClsContact Contact)
        {
            Console.Write("\n\nEnter First Name    : ");
            Contact.FirstName = Console.ReadLine().Trim();

            Console.Write("Enter Last Name     : ");
            Contact.LastName = Console.ReadLine().Trim();

            Console.Write("Enter Email         : ");
            Contact.Email = Console.ReadLine().Trim();

            Console.Write("Enter Phone         : ");
            Contact.Phone = Console.ReadLine().Trim();

            Console.Write("Enter Address       : ");
            Contact.Address = Console.ReadLine().Trim();

            Console.Write("Enter Date Of Birth : ");
            string DateOfBirth = Console.ReadLine().Trim();

            DateTime result;

            while (!DateTime.TryParse(DateOfBirth, out result))
            {
                Console.Write("Invalid Date Of Birth!\nEnter Vaild Date Of Birth : ");
                DateOfBirth = Console.ReadLine();
            }

            Contact.DateOfBirth = result;

            Console.Write("Enter Country       : ");
            Contact.Country = Console.ReadLine().Trim();

            Console.Write("Enter Image Path       : ");
            Contact.ImagePath = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(Contact.ImagePath))
                Contact.ImagePath = "";
        }

        static void AddNewContact()
        {
            ClsContact Contact = new ClsContact();

            FillContact(Contact);

            try
            {
                if (ClsCRUD_Operations.AddContact(Contact) == true)
                    Console.WriteLine("\n\nContact Adding Successfully:-");
                else
                    Console.WriteLine("\n\nContact Adding Faild -:");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\nErorr: {ex.Message}");
            }
            finally
            {
                GoBack();
            }
        }

        static void UpdateContactHelper(ClsContact Contact)
        {
            Console.Write("\n\nDo you want to update First Name (y , n) ? ");
            if (Console.ReadLine().ToLower() == "y")
            {
                Console.Write("Enter New First Name : ");
                Contact.FirstName = Console.ReadLine().Trim();
            }
            else
            {
                Console.WriteLine("First Name Not Changed.");
            }

            Console.Write("\nDo you want to update Last Name (y , n) ? ");
            if (Console.ReadLine().ToLower() == "y")
            {
                Console.Write("Enter New Last Name : ");
                Contact.LastName = Console.ReadLine().Trim();
            }
            else
            {
                Console.WriteLine("Last Name Not Changed.");
            }

            Console.Write("\nDo you want to update Email (y , n) ? ");
            if (Console.ReadLine().ToLower() == "y")
            {
                Console.Write("Enter New Email : ");
                Contact.Email = Console.ReadLine().Trim();
            }
            else
            {
                Console.WriteLine("Email Not Changed.");
            }

            Console.Write("\nDo you want to update Phone (y , n) ? ");
            if (Console.ReadLine().ToLower() == "y")
            {
                Console.Write("Enter New Phone : ");
                Contact.Phone = Console.ReadLine().Trim();
            }
            else
            {
                Console.WriteLine("Phone Not Changed.");
            }

            Console.Write("\nDo you want to update Address (y , n) ? ");
            if (Console.ReadLine().ToLower() == "y")
            {
                Console.Write("Enter New Address : ");
                Contact.Address = Console.ReadLine().Trim();
            }
            else
            {
                Console.WriteLine("Address Not Changed.");
            }

            Console.Write("\nDo you want to update Date Of Birth (y , n) ? ");
            if (Console.ReadLine().ToLower() == "y")
            {
                Console.Write("Enter New Date Of Birth : ");
                string DateOfBirth = Console.ReadLine();

                DateTime result;

                while (!DateTime.TryParse(DateOfBirth, out result))
                {
                    Console.Write("Invalid Date Of Birth!\nEnter Vaild Date Of Birth : ");
                    DateOfBirth = Console.ReadLine();
                }

                Contact.DateOfBirth = result;
            }
            else
            {
                Console.WriteLine("Date Of Birth Not Changed.");
            }

            Console.Write("\nDo you want to update Country (y , n) ? ");
            if (Console.ReadLine().ToLower() == "y")
            {
                Console.Write("Enter New Country : ");
                Contact.Country = Console.ReadLine().Trim();
            }
            else
            {
                Console.WriteLine("Country Not Changed.");
            }

            Console.Write("\nDo you want to update Image Path (y , n) ? ");
            if (Console.ReadLine().ToLower() == "y")
            {
                Console.Write("Enter New Image Path : ");
                Contact.ImagePath = Console.ReadLine().Trim();
            }
            else
            {
                Console.WriteLine("Image Path Not Changed.");
            }

            if (string.IsNullOrWhiteSpace(Contact.ImagePath))
                Contact.ImagePath = "";
        }

        static void UpdateContact()
        {
            Console.Write("\n\nEnter First Name : ");
            string FirstName = Console.ReadLine().Trim();

            Console.Write("Enter Last Name  : ");
            string LastName = Console.ReadLine().Trim();

            int ID = -1;

            try
            {
                ClsContact Contact = ClsCRUD_Operations.Find(FirstName, LastName, ref ID);

                if (Contact != null && ID > 0)
                {
                    UpdateContactHelper(Contact);

                    if (ClsCRUD_Operations.Update(Contact, ID))
                    {
                        Console.WriteLine("\n\nContact Updated Successfully :-\n");
                    }
                    else
                    {
                        Console.WriteLine("\n\nContact Updated Faild -:\n");
                    }
                }
                else
                {
                    Console.WriteLine("\n\nContact Not Found!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\nErorr: {ex.Message}");
            }
            finally
            {
                GoBack();
            }
        }

        static void ShowContactCard(ClsContact Contact, int ID)
        {
            Console.WriteLine("\n=================================================\n");
            Console.WriteLine($"Contact ID    : {ID}");
            Console.WriteLine($"First Name    : {Contact.FirstName}");
            Console.WriteLine($"Last Name     : {Contact.LastName}");
            Console.WriteLine($"Email         : {Contact.Email}");
            Console.WriteLine($"Phone         : {Contact.Phone}");
            Console.WriteLine($"Address       : {Contact.Address}");
            Console.WriteLine($"Date Of Birth : {Contact.DateOfBirth}");
            Console.WriteLine($"Country       : {Contact.Country}");
            Console.WriteLine($"Image Path    : {Contact.ImagePath}");
            Console.WriteLine("\n=================================================\n");
        }

        static void DeleteContact()
        {
            Console.Write("\n\nEnter First Name : ");
            string FirstName = Console.ReadLine().Trim();

            Console.Write("Enter Last Name  : ");
            string LastName = Console.ReadLine().Trim();

            int ID = -1;

            try
            {
                ClsContact Contact = ClsCRUD_Operations.Find(FirstName, LastName, ref ID);

                if (Contact != null && ID > 0)
                {
                    ShowContactCard(Contact, ID);

                    Console.Write("\nAre you sure delete this contact ? (y , n) ");
                    if (Console.ReadLine().ToLower() == "y")
                    {
                        if (ClsCRUD_Operations.Delete(ID))
                        {
                            Console.WriteLine("\n\nContact Deleted Successfully :-\n");
                        }
                        else
                        {
                            Console.WriteLine("\n\nContact Deleted Faild -:\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n\nContact Not Deleted.\n");
                    }
                }
                else
                {
                    Console.WriteLine("\n\nContact Not Found!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\nErorr: {ex.Message}");
            }
            finally
            {
                GoBack();
            }
        }

        static void FindContact()
        {
            Console.Write("\n\nEnter First Name : ");
            string FirstName = Console.ReadLine().Trim();

            Console.Write("Enter Last Name  : ");
            string LastName = Console.ReadLine().Trim();

            int ID = -1;

            try
            {
                ClsContact Contact = ClsCRUD_Operations.Find(FirstName, LastName, ref ID);

                if (Contact != null && ID > -1)
                {
                    ShowContactCard(Contact, ID);
                }
                else
                {
                    Console.WriteLine("\n\nContact Not Found!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\nErorr: {ex.Message}");
            }
            finally
            {
                GoBack();
            }
        }

        static void ShowAllContacts()
        {
            try
            {
                DataTable dataTable = ClsCRUD_Operations.GetAllContacts();

                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        Console.WriteLine(
                            $"\nID            : {row["ContactID"]}" +
                            $"\nFirst Name    : {row["FirstName"]}" +
                            $"\nLast Name     : {row["LastName"]}" +
                            $"\nEmail         : {row["Email"]}");
                        Console.WriteLine($"Phone         : {row["Phone"]}" +
                                          $"\nAddress       : {row["Address"]}" +
                                          $"\nDate Of Birth : {row["DateOfBirth"]}" +
                                          $"\nCountry       : {row["CountryName"]}" +
                                          $"\nImage Path    : {row["ImagePath"]}\n");
                    }
                }
                else
                {
                    Console.WriteLine("\n\nNot Contacts Found!\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\nErorr: {ex.Message}");
            }
            finally
            {
                GoBack();
            }
        }

        static void IsContactExist()
        {
            Console.Write("\n\nEnter First Name : ");
            string FirstName = Console.ReadLine().Trim();

            Console.Write("Enter Last Name  : ");
            string LastName = Console.ReadLine().Trim();

            try
            {
                if (ClsCRUD_Operations.IsExist(FirstName, LastName))
                {
                    Console.WriteLine("\n\nContact Exist.");
                }
                else
                {
                    Console.WriteLine("\n\nContact Not Exist!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\nErorr: {ex.Message}");
            }
            finally
            {
                GoBack();
            }
        }

        static void ShowCountryCard(ClsCountry Country, int CountryID)
        {
            Console.WriteLine("\n===============================\n");
            Console.WriteLine($"Country ID   : {CountryID}");
            Console.WriteLine($"Country Name : {Country.CountryName}");
            Console.WriteLine($"Phone Code   : {Country.PhoneCode}");
            Console.WriteLine($"Code         : {Country.Code}");
            Console.WriteLine("\n===============================\n");
        }

        static void FindCountry()
        {
            Console.Write("\n\nEnter Country Name : ");
            string CountryName = Console.ReadLine().Trim();

            int CountryID = -1;

            try
            {
                ClsCountry Country = ClsCRUD_Operations.FindCountry(CountryName, ref CountryID);

                if (Country != null && CountryID > 0)
                {
                    ShowCountryCard(Country, CountryID);
                }
                else
                {
                    Console.WriteLine("\n\nCountry Not Found!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\nErorr: {ex.Message}");
            }
            finally
            {
                GoBack();
            }
        }

        static void IsCountryExist()
        {
            Console.Write("\n\nEnter Country Name : ");
            string CountryName = Console.ReadLine().Trim();

            try
            {
                if (ClsCRUD_Operations.IsCountryExist(CountryName))
                {
                    Console.WriteLine("\n\nCountry Exist.");
                }
                else
                {
                    Console.WriteLine("\n\nCountry Not Exist!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\nErorr: {ex.Message}");
            }
            finally
            {
                GoBack();
            }
        }

        static void FillCountry(ClsCountry country)
        {
            Console.Write("\n\nEnter Country Name : ");
            country.CountryName = Console.ReadLine().Trim();

            Console.Write("Enter Phone Code : ");
            country.PhoneCode = Console.ReadLine().Trim();

            Console.Write("Enter Code: ");
            country.Code = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(country.PhoneCode))
                country.PhoneCode = "";

            if (string.IsNullOrWhiteSpace(country.Code))
                country.Code = "";
        }

        static void AddNewCountry()
        {
            ClsCountry country = new ClsCountry();

            FillCountry(country);

            try
            {
                if (ClsCRUD_Operations.AddCountry(country) == true)
                    Console.WriteLine("\n\nCountry Adding Successfully:-");
                else
                    Console.WriteLine("\n\nCountry Adding Faild -:");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\nErorr: {ex.Message}");
            }
            finally
            {
                GoBack();
            }
        }

        static void ShowAllCountries()
        {
            try
            {
                DataTable dataTable = ClsCRUD_Operations.GetAllCountries();

                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        Console.WriteLine($"\nCountry ID : {row["CountryID"]}\nCountry Name : {row["CountryName"]}\nCode : {row["Code"]}\nPhone Code : {row["PhoneCode"]}\n");
                    }
                }
                else
                {
                    Console.WriteLine("\n\nNot Country Found!\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\nErorr: {ex.Message}");
            }
            finally
            {
                GoBack();
            }
        }

        static void UpdateCountryHelper(ClsCountry Country)
        {
            Console.Write("\n\nDo you want to update Country Name (y , n) ? ");
            if (Console.ReadLine().ToLower() == "y")
            {
                Console.Write("Enter New Country Name : ");
                Country.CountryName = Console.ReadLine().Trim();
            }
            else
            {
                Console.WriteLine("Country Name Not Changed.");
            }

            Console.Write("\nDo you want to update Phone Code (y , n) ? ");
            if (Console.ReadLine().ToLower() == "y")
            {
                Console.Write("Enter New Phone Code : ");
                Country.PhoneCode = Console.ReadLine().Trim();
            }
            else
            {
                Console.WriteLine("Phone Code Not Changed.");
            }

            Console.Write("\nDo you want to update Code (y , n) ? ");
            if (Console.ReadLine().ToLower() == "y")
            {
                Console.Write("Enter New Code : ");
                Country.Code = Console.ReadLine().Trim();
            }
            else
            {
                Console.WriteLine("Code Not Changed.");
            }

            if (string.IsNullOrWhiteSpace(Country.PhoneCode))
                Country.PhoneCode = "";

            if (string.IsNullOrWhiteSpace(Country.Code))
                Country.Code = "";
        }

        static void UpdateCountry()
        {
            Console.Write("\n\nEnter Country Name : ");
            string CountryName = Console.ReadLine().Trim();

            int CountryID = -1;

            try
            {
                ClsCountry Country = ClsCRUD_Operations.FindCountry(CountryName, ref CountryID);

                if (Country != null && CountryID > 0)
                {
                    UpdateCountryHelper(Country);

                    if (ClsCRUD_Operations.UpdateCountry(Country, CountryID))
                    {
                        Console.WriteLine("\n\nCountry Updated Successfully :-\n");
                    }
                    else
                    {
                        Console.WriteLine("\n\nCountry Updated Faild -:\n");
                    }
                }
                else
                {
                    Console.WriteLine("\n\nCountry Not Found!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\nErorr: {ex.Message}");
            }
            finally
            {
                GoBack();
            }
        }

        public static bool PerformChoice()
        {
            Console.Clear();

            bool Work = true;

            ShowMainMenue();

            Console.Write("Choice what you want to do: ");

            byte result = 0;

            if (byte.TryParse(Console.ReadLine(), out result))
            {
                if (result > 0 && result < 13)
                {
                    switch (result)
                    {
                        case 1:
                            {
                                AddNewContact();
                                break;
                            }
                        case 2:
                            {
                                UpdateContact();
                                break;
                            }
                        case 3:
                            {
                                DeleteContact();
                                break;
                            }
                        case 4:
                            {
                                FindContact();
                                break;
                            }
                        case 5:
                            {
                                ShowAllContacts();
                                break;
                            }
                        case 6:
                            {
                                IsContactExist();
                                break;
                            }
                        case 7:
                            {
                                FindCountry();
                                break;
                            }
                        case 8:
                            {
                                IsCountryExist();
                                break;
                            }
                        case 9:
                            {
                                AddNewCountry();
                                break;
                            }
                        case 10:
                            {
                                ShowAllCountries();
                                break;
                            }
                        case 11:
                            {
                                UpdateCountry();
                                break;
                            }
                        case 12:
                            {
                                Work = false;
                                break;
                            }

                    }
                }
                else
                {
                    Console.Write("Wrong Choice!");
                    GoBack();
                }
            }
            else
            {
                Console.Write("Invalid Input!");
                GoBack();
            }

            return Work;
        }














    }
}
