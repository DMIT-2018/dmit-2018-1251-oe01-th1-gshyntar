<Query Kind="Statements">
  <Connection>
    <ID>2569a856-95d7-41a5-ae94-7affd8025423</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>COOLGAMERLAPTOP\MSSQLSERVER01</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Database>StartTed-2025-Sept (2)</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
</Query>

//Simple Linq Exercise

//Question 1

//ClubActivities.Select(x => new
//	{
//	Location = x.Location
//	}).Dump();

//Order by generally goes after the select, only times it should be before is if the variable is not in the select

ClubActivities
	.Where(x => x.StartDate.Value >= new DateTime(2025, 1, 1) && x.Name != "Btech Club Meeting" && x.CampusVenue.Location != "Scheduled Room")
	.Select(x => new
	{
		StartDate = x.StartDate.Value,
		Location = x.CampusVenue.Location,
		Club = x.Club.ClubName,
		Activity = x.Name
	})
	.OrderBy(x => x.StartDate)
	.Dump();
	
//Question 2
Programs
	.Where(x => x.ProgramCourses.Count(t => t.Required == true) >= 22)
	.Select(x => new
	{
		School = x.SchoolCode == "SAMIT" ? "School of Advance Media and IT" : x.SchoolCode == "SEET" ? "School of Electrical Engineering Technology" : "Unknown",
		Program = x.ProgramName,
		RequiredCourseCount = x.ProgramCourses.Count(t => t.Required == true),
		OptionalCourseCount = x.ProgramCourses.Count(t => t.Required == false)
	
	})
	.OrderBy(x => x.Program)
	.Dump();
	
//Question 3
Students
	.Where(x => x.Countries.CountryName != "CANADA" && x.StudentPayments.Count() == 0)
	.OrderBy(x => x.LastName)
	.Select(x => new
	{
		//ClubMembershipCount = x.ClubID.Count()
		
		//ClubMembershipCount = x.MemberID,
		//ClubMembershipCount = x.StudentNumber,
		StudentNumber = x.StudentNumber,
		CountryName = x.Countries.CountryName,
		FullName = x.FirstName + " " + x.LastName,
		ClubMembershipCount = x.ClubMembers.Count() == 0 ? "None" : x.ClubMembers.Count().ToString()
		
	})
	.Dump();
	
//Question 4
Employees
	.Where(x => x.ClassOfferings.Count() > 0 && x.Position.Description == "Instructor" && x.ReleaseDate == null)
	.OrderByDescending(x => x.ClassOfferings.Count())
	.ThenBy(x => x.LastName)
	.Select(x => new
	{
		ProgramName = x.Program.ProgramName,
		FullName = x.FirstName + " " + x.LastName,
		WorkLoad = x.ClassOfferings.Count() > 24 ? "High" : x.ClassOfferings.Count() > 8 ? "Med" : "Low",
	})
	.Dump();
	
//Question 5
Clubs
	.Select(x => new
	{
		Supervisor = (x.EmployeeID == null) ? "Unknown" : (x.Employee.FirstName + " " + x.Employee.LastName),
		Club = x.ClubName,
		MemberCount = x.ClubMembers.Count(),
		Activities = x.ClubActivities.Count() == 0 ? "None Schedule" : x.ClubActivities.Count().ToString()
	})
	.OrderByDescending(x => x.MemberCount)
	.Dump();