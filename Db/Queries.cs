namespace Backend.Db
{
    public static class Queries
    {
        public const string LoginQuery = @"
BEGIN;
    SELECT u.id, u.login, AVG(w.score_avg) as avgScore
    FROM public.user u
    JOIN public.work w on w.user_id = u.id
    WHERE u.login = @login
	    AND u.password = @password
    GROUP BY u.id, u.login;

    UPDATE public.user
    SET last_login_at = NOW();
COMMIT;";

        public const string RegisterQuery = @"
INSERT INTO public.user (login, name, email, password, registered_at, last_login_at)
VALUES (@login, null, null, @password, NOW(), NOW())
RETURNING id as userId;";



        public const string AddCommentQuery = @"
INSERT INTO public.comment (text, score_id, user_id, published_at)
VALUES (@text, @scoreId, @userId, NOW())
RETURNING id as commentId;";

        public const string EditCommentQuery = @"
UPDATE public.comment
SET text = @text,
    score_id = @scoreId
WHERE id = @id
RETURNING id as commentId;";

        public const string RemoveCommentQuery = @"
DELETE FROM public.comment
WHERE id = @id
RETURNING id as commentId;";

        public const string GetCommentsAllQuery = @"
SELECT c.text, c.score_id, u.login, c.published_at, c.work_id
FROM public.comment c
JOIN public.user u ON u.id = c.user_id
WHERE c.work_id = @workId
ORDER BY c.published_at DESC;";
        


        public const string AddWorkQuery = @"
INSERT INTO public.work (name, description, user_id, data, published_at, edited_at)
VALUES (@name, @description, 1, @data, NOW(), NOW())
RETURNING id as workId;";

        public const string EditWorkQuery = @"
UPDATE public.work
SET name = @name
    description = @description,
    data = @data
    edited_at = NOW()
WHERE id = @id
RETURNING id as workId;";

        public const string RemoveWorkQuery = @"
DELETE FROM public.work
WHERE id = @id
RETURNING id as workId;";


        public const string GetWorkDetailsQuery = @"
SELECT w.name, w.description, u.user, w.data, w.published_at, w.edited_at
FROM public.work w
JOIN public.user u ON u.id = w.user_id;";
        
        public const string GetWorksAllQuery = @"
SELECT w.name, u.user, w.preview
FROM public.work w
JOIN public.user u ON u.id = w.user_id;";
        
        public const string GetWorksByFilterQuery = @"
SELECT w.name, u.user, w.preview
FROM public.work w
JOIN public.user u ON u.id = w.user_id
WHERE w.name LIKE '%'||@nameFilter||'%'
	AND w.description LIKE '%'||@title||'%'
	AND p.address LIKE '%'||@address||'%';";

        public const string CheckLoginQuery = @"
SELECT CASE WHEN count(1) >= 1 THEN true
            ELSE false
       END as isLoginExists
FROM public.user
WHERE login = @login";
    };
}
