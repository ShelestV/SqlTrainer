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

create table public."topics" (
  "id" UUID constraint "topics_id_pk" primary key,
  "name" VARCHAR(100) constraint "topics_name_notnull" not null
);

create table public."tests" (
  "id" UUID constraint "tests_id_pk" primary key,
  "topic_id" UUID constraint "tests_topicid_notnull" not null,
  "creation_date" Date,
  "difficulty" int,
  constraint "tests_topicid_topics_fk" foreign key ("topic_id") references "topics" ("id")
);

create table public."questions" (
  "id" UUID constraint "questions_id_pk" primary key,
  "body" VARCHAR(150) constraint "questions_body_notnull" not null,
  "max_mark" double precision constraint "questions_maxmark_notnull" not null
);

create table public."correct_answers" (
  "id" UUID constraint "correctanswers_id_pk" primary key,
  "body" VARCHAR(150) constraint "correctanswers_body_notnull" not null,
  "question_id" UUID constraint "correctanswers_questionid_notnull" not null,
  constraint "correctanswers_questionid_question_fk" foreign key ("question_id") references "questions" ("id")
);

create table public."test_questions" (
  "test_id" UUID constraint "testquestions_testid_notnull" not null,
  "question_id" UUID constraint "testquestions_questionid_notnull" not null,
  constraint "testquestions_testid_questionid_pk" primary key ("test_id", "question_id"),
  constraint "testquestions_testid_tests_fk" foreign key ("test_id") references "tests" ("id"),
  constraint "testquestions_questionid_questions_fk" foreign key ("question_id") references "questions" ("id")
);

create table public."user_answers" (
  "id" UUID constraint "useranswers_id_pk" primary key,
  "test_id" UUID constraint "useranswers_testid_notnull" not null,
  "question_id" UUID constraint "useranswers_questionid_notnull" not null,
  "body" VARCHAR(150) constraint "useranswers_body_notnull" not null,
  "user_id" UUID constraint "useranswers_userid_notnull" not null,
  "score" double precision constraint "useranswers_score_notnull" not null,
  constraint "useranswers_testid_questionid_testquestions_fk" foreign key ("test_id", "question_id") references "test_questions" ("test_id", "question_id"), 
  constraint "usernaswers_userid_users_fk" foreign key ("user_id") references "users" ("id")
);