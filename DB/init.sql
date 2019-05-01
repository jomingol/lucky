USE lucky;

DROP TABLE IF EXISTS lucky_account;
CREATE TABLE lucky_account(
  AccountId INT(11) NOT NULL COMMENT '账户Id',
  AllowCount INT(10) NULL DEFAULT 0 COMMENT '账户允许剩余抽奖次数',
  PRIMARY KEY (AccountId)
) ENGINE =innodb AUTO_INCREMENT=1 DEFAULT CHARSET =utf8 COMMENT '账户允许剩余抽奖次数';

DROP TABLE IF EXISTS lucky_product;
CREATE TABLE lucky_product
(
   ProductId INT(11)NOT NULL AUTO_INCREMENT COMMENT '产品Id',
   ProductCode NVARCHAR(50) NULL COMMENT '产品编号',
   ProductName NVARCHAR(128) NULL COMMENT '产品名称',
   ProductStore INT(10) NULL COMMENT '产品库存' DEFAULT 0,
   ProductLuckyRateMin INT(2) NULL COMMENT '中奖概率小' DEFAULT 1,
   ProductLuckyRateMax INT(2) NULL COMMENT '中奖概率da' DEFAULT 1,
   ProductStatus INT(2) NULL COMMENT '状态' DEFAULT 1,
   LuckyIndex NVARCHAR(50) NULL DEFAULT '1' COMMENT '中奖停留位置',
   IsLucky INT(2) NULL COMMENT '是否中奖' DEFAULT 1,
   CreatedAt DATETIME DEFAULT NULL COMMENT '创建时间',
   UpdatedAt DATETIME DEFAULT NULL COMMENT '更新时间',
   PRIMARY KEY (ProductId)
)ENGINE=innodb auto_increment=1 default charset=utf8 comment = '抽奖产品表';

DROP TABLE IF EXISTS lucky_result;
CREATE TABLE lucky_result(
    ResultId INT(11) NOT NULL AUTO_INCREMENT COMMENT '中奖结果Id',
    ProductId INT(10) NULL DEFAULT 0 COMMENT '产品Id',
    ProductCode NVARCHAR(50) NULL COMMENT '产品编号',
    ProductName NVARCHAR(128) NULL COMMENT '产品名称',
    AccountId INT(11) NULL COMMENT '账户Id',
    LuckyAccount NVARCHAR(50) NULL COMMENT '中奖账号',
    CreatedAt DATETIME DEFAULT  NULL COMMENT '创建时间',
    PRIMARY KEY (ResultId)
)ENGINE =innodb AUTO_INCREMENT=1 DEFAULT CHARSET =utf8 COMMENT ='中奖结果';

DROP TABLE IF EXISTS lucky_action;
CREATE TABLE lucky_action(
    ActionId INT(11) NOT NULL AUTO_INCREMENT COMMENT '抽奖Id',
    AccountId INT(11) NULL COMMENT '账户Id',
    LuckyAccount NVARCHAR(50) NULL COMMENT '抽奖账号',
    CreatedAt DATETIME DEFAULT  NULL COMMENT '创建时间',
    PRIMARY KEY (ActionId)
)ENGINE =innodb AUTO_INCREMENT=1 DEFAULT CHARSET =utf8 COMMENT ='抽奖记录';

INSERT lucky_account(AccountId,AllowCount)VALUES (1,15000),(2,20),(3,10000);

INSERT lucky_product(ProductCode,ProductName,ProductStore,ProductStatus,LuckyIndex,ProductLuckyRateMin,ProductLuckyRateMax,IsLucky,CreatedAt,UpdatedAt)VALUES
  ('code1','优惠券满减1',100,1,0,1,20,1,now(),now()),('code2','优惠券满减2',100,1,2,21,25,1,now(),now()),('code3','优惠券满减3',100,1,4,26,50,1,now(),now()),('code4','谢谢惠顾',100000,1,'1,3,5',51,100,0,now(),now());