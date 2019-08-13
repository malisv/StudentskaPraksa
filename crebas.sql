/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     11.8.2019. 17.10.32                          */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DetaljiPraktikanta') and o.name = 'FK_DETALJIP_DETALJIPR_PRAKTIKA')
alter table DetaljiPraktikanta
   drop constraint FK_DETALJIP_DETALJIPR_PRAKTIKA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Praktikant') and o.name = 'FK_PRAKTIKA_PRAKTIKAN_STUDENTS')
alter table Praktikant
   drop constraint FK_PRAKTIKA_PRAKTIKAN_STUDENTS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PraktikantNaVanNastavnojAktivnosti') and o.name = 'FK_PRAKTIKA_RELATIONS_PRAKTIKA')
alter table PraktikantNaVanNastavnojAktivnosti
   drop constraint FK_PRAKTIKA_RELATIONS_PRAKTIKA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PraktikantNaVanNastavnojAktivnosti') and o.name = 'FK_PRAKTIKA_RELATIONS_VANNASTA')
alter table PraktikantNaVanNastavnojAktivnosti
   drop constraint FK_PRAKTIKA_RELATIONS_VANNASTA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DetaljiPraktikanta')
            and   type = 'U')
   drop table DetaljiPraktikanta
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Praktikant')
            and   name  = 'PraktikantNaPraksi_FK'
            and   indid > 0
            and   indid < 255)
   drop index Praktikant.PraktikantNaPraksi_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Praktikant')
            and   type = 'U')
   drop table Praktikant
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PraktikantNaVanNastavnojAktivnosti')
            and   name  = 'Relationship_5_FK'
            and   indid > 0
            and   indid < 255)
   drop index PraktikantNaVanNastavnojAktivnosti.Relationship_5_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PraktikantNaVanNastavnojAktivnosti')
            and   name  = 'Relationship_4_FK'
            and   indid > 0
            and   indid < 255)
   drop index PraktikantNaVanNastavnojAktivnosti.Relationship_4_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PraktikantNaVanNastavnojAktivnosti')
            and   type = 'U')
   drop table PraktikantNaVanNastavnojAktivnosti
go

if exists (select 1
            from  sysobjects
           where  id = object_id('StudentskaPraksa')
            and   type = 'U')
   drop table StudentskaPraksa
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VanNastavnaAktivnost')
            and   type = 'U')
   drop table VanNastavnaAktivnost
go

/*==============================================================*/
/* Table: DetaljiPraktikanta                                    */
/*==============================================================*/
create table DetaljiPraktikanta (
   PraktikantId         int                  not null,
   Ime                  varchar(30)          not null,
   Prezime              varchar(30)          not null,
   BrojTelefona         varchar(12)          not null,
   constraint PK_DETALJIPRAKTIKANTA primary key nonclustered (PraktikantId)
)
go

/*==============================================================*/
/* Table: Praktikant                                            */
/*==============================================================*/
create table Praktikant (
   PraktikantId         int                  identity,
   StudentskaPraksaId   int                  not null,
   Username             varchar(30)          not null,
   constraint PK_PRAKTIKANT primary key nonclustered (PraktikantId)
)
go

/*==============================================================*/
/* Index: PraktikantNaPraksi_FK                                 */
/*==============================================================*/
create index PraktikantNaPraksi_FK on Praktikant (
StudentskaPraksaId ASC
)
go

/*==============================================================*/
/* Table: PraktikantNaVanNastavnojAktivnosti                    */
/*==============================================================*/
create table PraktikantNaVanNastavnojAktivnosti (
   VanNastavnaAktivnostId int                  not null,
   PraktikantId         int                  not null,
   constraint PK_PRAKTIKANTNAVANNASTAVNOJAKT primary key nonclustered (VanNastavnaAktivnostId, PraktikantId)
)
go

/*==============================================================*/
/* Index: Relationship_4_FK                                     */
/*==============================================================*/
create index Relationship_4_FK on PraktikantNaVanNastavnojAktivnosti (
PraktikantId ASC
)
go

/*==============================================================*/
/* Index: Relationship_5_FK                                     */
/*==============================================================*/
create index Relationship_5_FK on PraktikantNaVanNastavnojAktivnosti (
VanNastavnaAktivnostId ASC
)
go

/*==============================================================*/
/* Table: StudentskaPraksa                                      */
/*==============================================================*/
create table StudentskaPraksa (
   StudentskaPraksaId   int                  identity,
   Godina               int                  not null,
   constraint PK_STUDENTSKAPRAKSA primary key nonclustered (StudentskaPraksaId)
)
go

/*==============================================================*/
/* Table: VanNastavnaAktivnost                                  */
/*==============================================================*/
create table VanNastavnaAktivnost (
   VanNastavnaAktivnostId int                  identity,
   Naziv                varchar(20)          not null,
   Lokacija             varchar(20)          not null,
   Vrijeme              datetime             not null,
   constraint PK_VANNASTAVNAAKTIVNOST primary key nonclustered (VanNastavnaAktivnostId)
)
go

alter table DetaljiPraktikanta
   add constraint FK_DETALJIP_DETALJIPR_PRAKTIKA foreign key (PraktikantId)
      references Praktikant (PraktikantId)
go

alter table Praktikant
   add constraint FK_PRAKTIKA_PRAKTIKAN_STUDENTS foreign key (StudentskaPraksaId)
      references StudentskaPraksa (StudentskaPraksaId)
go

alter table PraktikantNaVanNastavnojAktivnosti
   add constraint FK_PRAKTIKA_RELATIONS_PRAKTIKA foreign key (PraktikantId)
      references Praktikant (PraktikantId)
go

alter table PraktikantNaVanNastavnojAktivnosti
   add constraint FK_PRAKTIKA_RELATIONS_VANNASTA foreign key (VanNastavnaAktivnostId)
      references VanNastavnaAktivnost (VanNastavnaAktivnostId)
go

