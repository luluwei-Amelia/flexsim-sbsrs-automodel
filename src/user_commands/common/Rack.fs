/**Custom Code*/
int RackType = Table("RackTable")[9][2];//结构类型
int numrow = Table("RackTable")[1][2];//排数
int number = Table("RackTable")[2][2] ;// 列数
int numlevels = Table("RackTable")[3][2];// 层数

double bayWidth = Table("RackTable")[4][2]; // 货位宽
double rowwidth = Table("RackTable")[5][2];// 货格长（排宽）
double levelHeight = Table("RackTable")[6][2];// 货位高（单层高）

double AisleWidth = Table("RackTable")[7][2];//巷道宽
double BackInterval = Table("RackTable")[10][2];//巷道背部间隙

double ToteLength = Table("BoxTable")[1][2];
double ToteWidth = Table("BoxTable")[2][2];
double ToteHeight = Table("BoxTable")[3][2];
double BoxLength = Table("BoxTable")[4][2];
double BoxWidth = Table("BoxTable")[5][2];
double BoxHeight = Table("BoxTable")[6][2];


//设置货物尺寸
setnodenum(Model.find("Tools/FlowItemBin/Box/Box>spatial/spatialsx"),BoxLength);
setnodenum(Model.find("Tools/FlowItemBin/Box/Box>spatial/spatialsy"),BoxWidth);
setnodenum(Model.find("Tools/FlowItemBin/Box/Box>spatial/spatialsz"),BoxHeight);

//设置料箱尺寸
setnodenum(Model.find("Tools/FlowItemBin/Tote/Tote>spatial/spatialsx"),ToteLength);
setnodenum(Model.find("Tools/FlowItemBin/Tote/Tote>spatial/spatialsy"),ToteWidth);
setnodenum(Model.find("Tools/FlowItemBin/Tote/Tote>spatial/spatialsz"),ToteHeight);

//设置货架标签
string labelname1 = "Shelf_Name";
string labelname2 = "Shelf_locx";
string labelname3 = "Shelf_locy";

for(int i=1; i<=numrow;i++)
{
	treenode libraryRack = library().find("?Rack");
	Object firstRack = createinstance(libraryRack, model());
	firstRack.name="Rack"+numtostring(i);
	firstRack.labels.assert(labelname1).value = i;
	firstRack.setSize(bayWidth,rowwidth,levelHeight);

	//设置货架参数
    setvarnum(libraryRack, "maxcontent", RackType*number*numlevels);
	setvarnum(libraryRack, "columnspacing", 2);
	setvarnum(libraryRack, "extendcolumn", 1);
	function_s(libraryRack, "BasicRefreshTable", firstRack, numlevels, number,  levelHeight, bayWidth);

	//设定货架位置
	firstRack.location.x = 0;
	firstRack.labels.assert(labelname2).value = 0;

	if(i%2==0)
	{
		firstRack.location.y = (bayWidth)*(i-1)+AisleWidth*i/2+BackInterval*(i/2-1);
		firstRack.labels.assert(labelname3).value = firstRack.location.y;
	}
	else
	{
		firstRack.location.y = (2*bayWidth+BackInterval+AisleWidth)*(i-1)/2;
		firstRack.labels.assert(labelname3).value = firstRack.location.y;
	}

}
