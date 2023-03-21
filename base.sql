/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     13/02/2022 15:14:38                          */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CLIENTE') and o.name = 'FK_CLIENTE_REFERENCE_FORMAPAG')
alter table CLIENTE
   drop constraint FK_CLIENTE_REFERENCE_FORMAPAG
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DETALLE_FACTURA') and o.name = 'FK_DETALLE__RELATIONS_FACTURA')
alter table DETALLE_FACTURA
   drop constraint FK_DETALLE__RELATIONS_FACTURA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DETALLE_FACTURA') and o.name = 'FK_DETALLE__RELATIONS_PRODUCTO')
alter table DETALLE_FACTURA
   drop constraint FK_DETALLE__RELATIONS_PRODUCTO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('FACTURA') and o.name = 'FK_FACTURA_RELATIONS_CLIENTE')
alter table FACTURA
   drop constraint FK_FACTURA_RELATIONS_CLIENTE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CLIENTE')
            and   name  = 'RELATIONSHIP_5_FK'
            and   indid > 0
            and   indid < 255)
   drop index CLIENTE.RELATIONSHIP_5_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CLIENTE')
            and   type = 'U')
   drop table CLIENTE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DETALLE_FACTURA')
            and   name  = 'RELATIONSHIP_1_FK'
            and   indid > 0
            and   indid < 255)
   drop index DETALLE_FACTURA.RELATIONSHIP_1_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DETALLE_FACTURA')
            and   type = 'U')
   drop table DETALLE_FACTURA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ESTADO')
            and   type = 'U')
   drop table ESTADO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('FACTURA')
            and   name  = 'RELATIONSHIP_3_FK'
            and   indid > 0
            and   indid < 255)
   drop index FACTURA.RELATIONSHIP_3_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('FACTURA')
            and   type = 'U')
   drop table FACTURA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('FORMAPAGO')
            and   type = 'U')
   drop table FORMAPAGO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PRODUCTOS')
            and   name  = 'RELATIONSHIP_2_FK'
            and   indid > 0
            and   indid < 255)
   drop index PRODUCTOS.RELATIONSHIP_2_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PRODUCTOS')
            and   type = 'U')
   drop table PRODUCTOS
go

/*==============================================================*/
/* Table: CLIENTE                                               */
/*==============================================================*/
create table CLIENTE (
   ID_CLIENTE          int NOT NULL IDENTITY(1,1),
   ID_FORMAPAGO         int                  null,
   CEDULA               varchar(Max)         null,
   NOMBRE               varchar(Max)         null,
   APELLIDO             varchar(Max)         null,
   DIRECCION            varchar(Max)         null,
   TELEFONO             int                  null,
   EMAIL                varchar(Max)         null,
   ESTADO_CLIENTE       int                  null,
   constraint PK_CLIENTE primary key nonclustered (ID_CLIENTE)
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_5_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_5_FK on CLIENTE (
ID_FORMAPAGO ASC
)
go

/*==============================================================*/
/* Table: DETALLE_FACTURA                                       */
/*==============================================================*/
create table DETALLE_FACTURA (
   ID_DETALLE           int NOT NULL IDENTITY(1,1),
   ID_PRODUCTO          int                  null,
   COD_FACTURA          int                  null,
   PRECIO_TOTAL         decimal              null,
   PRECIO_PRODUCTO      decimal              null,
   CANTIDAD_DETALLE     int                  null,
   ESTADO_DETALLE       int                  null,
   constraint PK_DETALLE_FACTURA primary key nonclustered (ID_DETALLE)
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_1_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_1_FK on DETALLE_FACTURA (
COD_FACTURA ASC
)
go

/*==============================================================*/
/* Table: ESTADO                                                */
/*==============================================================*/
create table ESTADO (
   ID_ESTADO            int NOT NULL  IDENTITY(1,1),
   DESCRIPCION_ESTADO   varchar(Max)         null,
   constraint PK_ESTADO primary key nonclustered (ID_ESTADO)
)
go

/*==============================================================*/
/* Table: FACTURA                                               */
/*==============================================================*/
create table FACTURA (
   COD_FACTURA          int                  not null,
   ID_CLIENTE           int                  null,
   FECHA_FACTURA        datetime             null,
   SUB_TOTAL            decimal              null,
   TOTAL                decimal              null,
   SUB_TOTAL_IVA        decimal              null,
   ESTADO_FACTURA       int                  null,
   constraint PK_FACTURA primary key nonclustered (COD_FACTURA)
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_3_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_3_FK on FACTURA (
ID_CLIENTE ASC
)
go

/*==============================================================*/
/* Table: FORMAPAGO                                             */
/*==============================================================*/
create table FORMAPAGO (
   ID_FORMAPAGO        int NOT NULL IDENTITY(1,1),
   DESCRIPCION_FORMA    varchar(Max)         null,
   ESTADO_FORMAPAGO     int                  null,
   constraint PK_FORMAPAGO primary key nonclustered (ID_FORMAPAGO)
)
go

/*==============================================================*/
/* Table: PRODUCTOS                                             */
/*==============================================================*/
create table PRODUCTOS (
   ID_PRODUCTO          int NOT NULL IDENTITY(1,1),
   DESCRIPCION_PRODUCTO varchar(Max)         null,
   CANTIDAD_PRODUCTO    int                  null,
   PRECIO_UNITARIO      decimal              null,
   ESTADO_PRODUCTO      int                  null,
   constraint PK_PRODUCTOS primary key nonclustered (ID_PRODUCTO)
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_2_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_2_FK on PRODUCTOS (
ID_PRODUCTO ASC
)
go

alter table CLIENTE
   add constraint FK_CLIENTE_REFERENCE_FORMAPAG foreign key (ID_FORMAPAGO)
      references FORMAPAGO (ID_FORMAPAGO)
go

alter table DETALLE_FACTURA
   add constraint FK_DETALLE__RELATIONS_FACTURA foreign key (COD_FACTURA)
      references FACTURA (COD_FACTURA)
go

alter table DETALLE_FACTURA
   add constraint FK_DETALLE__RELATIONS_PRODUCTO foreign key (ID_PRODUCTO)
      references PRODUCTOS (ID_PRODUCTO)
go

alter table FACTURA
   add constraint FK_FACTURA_RELATIONS_CLIENTE foreign key (ID_CLIENTE)
      references CLIENTE (ID_CLIENTE)
go

