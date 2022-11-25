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
$$