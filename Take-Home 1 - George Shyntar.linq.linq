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

ClubActivities
	.Where(x => x.StartDate.Value >= new DateTime(2025, 1, 1) && x.Name != "Btech Club Meeting" && x.Location != "Scheduled Room")
	.OrderBy(x => x.StartDate.Value)
	.Select(x => new
	{
		StartDate = x.StartDate.Value,
		Location = x.Location,
		Club = x.Club.ClubName,
		Activity = x.Name
	})
	.Dump();
	
//Question 2
Programs
	.Where(x => x.ProgramCourses.Count(t => t.Required == true) >= 22)
	.OrderBy(x => x.ProgramName)
	.Select(x => new
	{
		School = x.SchoolCode == "SAMIT" ? "School of Advance Media and IT" : x.SchoolCode == "SEET" ? "School of Electrical Engineering Technology" : "Unknown",
		Program = x.ProgramName,
		RequiredCourseCount = x.ProgramCourses.Count(t => t.Required == true),
		OptionalCourseCount = x.ProgramCourses.Count(t => t.Required == false)
	
	})
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
