create table public."tests" (
  "id" UUID constraint "tests_id_pk" primary key,
  "topic_id" UUID constraint "tests_topicid_notnull" not null,
  "creation_date" Date,
  "difficulty" int
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
  constraint "useranswers_testid_questionid_testquestions_fk" foreign key ("test_id", "question_id") references "test_questions" ("test_id", "question_id")
);

create or replace procedure public."insert_test"
(
  in "Id" uuid,
  in "TopicId" uuid,
  in "CreationDate" Date,
  in "Difficulty" int
)
language 'sql' as $$
  insert into public.tests(
  id, topic_id, creation_date, difficulty)
  values ("Id", "TopicId", "CreationDate", "Difficulty");
$$;

create or replace procedure public."insert_test_question"(
	in "TestId" uuid,
	in "QuestionId" uuid)
language 'sql'
as $$
	insert into public.test_questions(
	test_id, question_id)
	values ("TestId", "QuestionId");
$$;


create or replace procedure public."insert_user_answer"
(
  in "Id" uuid,
  in "TestId" uuid,
  in "QuestionId" uuid,
  in "Body" varchar (150),
  in "UserId" uuid,
  in "Score" double precision
)
language 'sql' as $$
  insert into public.user_answers(
  id, test_id, question_id, body, user_id, score)
  values ("Id", "TestId", "QuestionId", "Body", "UserId", "Score");
$$;

create or replace procedure public."insert_question"
(
    in "question_id" uuid,
    in "question_body" varchar (150),
    in "question_max_mark" double precision,
    in "answer_id" uuid,
    in "answer_body" varchar (150)
)
language 'sql' as $$
    insert into public."questions" ("id", "body", "max_mark")
    values ("question_id", "question_body", "question_max_mark");
    
    insert into public."correct_answers" ("id", "body", "question_id")
    values ("answer_id", "answer_body", "question_id");
$$;