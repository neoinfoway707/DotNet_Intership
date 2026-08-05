SELECT * FROM Students;
SELECT * FROM Subjects;
SELECT * FROM Examinations;

select stud.student_id, stud.student_name, sub.subject_name, count(exam.subject_name) as attended_exams 
from Students stud
cross join Subjects sub
left join Examinations exam on exam.student_id = stud.student_id and exam.subject_name = sub.subject_name
group by sub.subject_name,stud.student_id , stud.student_name
order by stud.student_id, sub.subject_name;