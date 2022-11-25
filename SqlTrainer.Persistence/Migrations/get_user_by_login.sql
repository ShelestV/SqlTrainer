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