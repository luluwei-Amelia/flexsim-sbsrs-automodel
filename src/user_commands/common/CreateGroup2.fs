/**Custom Code*/
int RowNum = Table("RackTable")[1][2];//排数
int BayNum = Table("RackTable")[2][2] ;// 列数
int TierNum = Table("RackTable")[3][2];// 层数
int AisleNum= Table("RackTable")[8][2];
int ShuttleNum = Table("ShuttleTable")[4][2];

int SortConveyorNum=Table("ConveyorTable")[6][2];
int PutConveyorNum=Table("UpTable")[1][2];


string groupname1="Station_Group";
Group group1=Group(groupname1);
for(int i=1; i<=SortConveyorNum;i++){
	treenode newmember=Model.find("Station"+numtostring(i));
	group1.addMember(newmember);
};


Group group2=Group("InEle_Group");
for(int i=1; i<=AisleNum;i++){
	treenode newmember=Model.find("Elevator"+numtostring(i));
	group2.addMember(newmember);
};

Group group3=Group("OutEle_Group");
for(int i=1; i<=AisleNum;i++){
	treenode newmember=Model.find("Elevator"+numtostring(2*i));
	group3.addMember(newmember);
};

Group group4=Group("Source_Group");
for(int i=1; i<=PutConveyorNum;i++){
	treenode newmember=Model.find("source1"+numtostring(i));
	group4.addMember(newmember);
};

Group group5=Group("Sink_Group");
for(int i=1; i<=PutConveyorNum;i++){
	treenode newmember=Model.find("pickSink");
	group5.addMember(newmember);
};

if(Table("模式选择")[1][2]=="C")
{
	Group group2=Group("InEle_Group");
	for(int i=1; i<=AisleNum;i++){
		treenode newmember=Model.find("InElevator"+numtostring(i));
		group2.addMember(newmember);
};
}
