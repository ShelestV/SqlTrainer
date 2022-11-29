--User service
create table public."roles" (
  "id" UUID constraint "roles_id_pk" primary key,
  "name" VARCHAR(50) constraint "roles_name_notnull" not null
);

create table public."groups" (
  "id" UUID constraint "groups_id_pk" primary key,
  "name" VARCHAR(50) constraint "groups_name_notnull" not null
);

create table public."users" (
  "id" UUID constraint "users_id_pk" primary key,
  "name" VARCHAR(50) constraint "users_name_notnull" not null,
  "login" VARCHAR(100) constraint "users_login_unique" unique constraint "users_login_notnull" not null,
  "hash_password" VARCHAR(100) constraint "users_hashpassword_notnull" not null,
  "role_id" UUID constraint "users_userid_notnull" not null,
  "group_id" UUID,
  "face_image" VARCHAR(50) constraint "users_faceimage_notnull" not null,
  "rate" decimal,
  constraint "users_roleid_roles_fk" foreign key ("role_id") references "roles" ("id"),
  constraint "users_groupid_groups_fk" foreign key ("group_id") references "groups" ("id")
);

create or replace function "get_user_by_login"
(
    in "user_login" varchar (50)
)
returns table(
    "id" uuid, 
    "name" varchar (50), 
    "login" varchar (100), 
    "hash_password" varchar(100), 
    "face_image" varchar(50), 
    "rate" numeric,
    "role_id" uuid,
    "group_id" uuid,
    "role" json,
    "group" json)
language 'plpgsql'
as $$
begin
    return query 
        select u."id", u."name", u."login", u."hash_password", u."face_image", u."rate", u."role_id", u."group_id", row_to_json(r), row_to_json(g)
        from public."users" u
            inner join public."roles" r on u."role_id" = r."id"
            inner join public."groups" g on u."group_id" = g."id"
        where u."login" = "user_login";
end;
$$;

create or replace procedure public."insert_user"
(
  in "Id" uuid,
  in "Name" varchar (50),
  in "Login" varchar (100),
  in "HashPassword" varchar (100),
  in "RoleId" uuid,
  in "GroupId" uuid,
  in "FaceImage" varchar (50),
  in "Rate" double precision
)
language 'sql' as $$
  insert into public.users(
  id, name, login, hash_password, role_id, group_id, face_image, rate)
  values ("Id", "Name", "Login", "HashPassword", "RoleId", "GroupId", "FaceImage", "Rate")
$$;

create or replace procedure public."insert_groups"
(
  in "Id" uuid,
  in "Name" varchar (50)
)
language 'sql' as $$
  insert into public.groups(
  id, name)
  values ("Id", "Name");
$$;

