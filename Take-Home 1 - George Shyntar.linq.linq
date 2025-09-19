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
	