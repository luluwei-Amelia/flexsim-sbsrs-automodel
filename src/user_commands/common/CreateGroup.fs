/**Custom Code*/
int Row = Table("RackTable")[1][2];//排数
int Bay = Table("RackTable")[2][2] ;// 列数
int Tier = Table("RackTable")[3][2];// 层数
int Aisle= Table("RackTable")[8][2];
int ShuttleNum = Table("ShuttleTable")[4][2];

int SortConveyorNum=Table("ConveyorTable")[6][2];

string groupname="Rack_Group";
Group group=Group(groupname);
for(int i=1; i<=Row;i++){
	treenode newmember=Model.find("Rack"+numtostring(i));
	group.addMember(newmember);
};

string groupname1="Shuttle_Group";
Group group1=Group(groupname1);
for(int i=1; i<=Row/2;i++){
	for(int j=1;j<=ShuttleNum;j++){
	treenode newmember=Model.find("TaskExecuter"+numtostring(i)+numtostring(j));
	group1.addMember(newmember);
	}
};

//string groupname3="Station_Group";
//Group group3=Group(groupname3);
//for(int i=1; i<=SortConveyorNum;i++){
//	treenode newmember=Model.find("Station"+numtostring(i));
//	group3.addMember(newmember);
//};


//string groupname4="Elevator_Group2";
//Group group4=Group(groupname4);
//for(int i=1; i<=Row;i++){
//	treenode newmember=Model.find("Elevator"+numtostring(i));
//	group4.addMember(newmember);
//};
