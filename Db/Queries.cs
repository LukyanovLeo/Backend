namespace Backend.Db
{
    public static class Queries
    {
        public const string LoginQuery = @"
BEGIN;
    SELECT COUNT(1)
    FROM public.user
    WHERE login = @login
        AND password = @password;

    UPDATE public.user
    SET last_login_at = NOW();
COMMIT;";

        public const string RegisterQuery = @"
INSERT INTO public.user (login, name, email, password, registered_at, last_login_at)
VALUES (@login, @name, @email, @password, NOW(), NOW())";

        public const string AddCommentQuery = @"
INSERT INTO public.comment (text, score_id, user_id, published_at)
VALUES (@text, @scoreId, @userId, NOW())";

        public const string EditCommentQuery = @"
UPDATE public.comment
SET text = @text,
    score_id = @scoreId
WHERE id = @id";

        public const string RemoveCommentQuery = @"
DELETE FROM public.comment
WHERE id = @id";
        
        public const string AddWorkQuery = @"
INSERT INTO public.work (name, description, user_id, data, published_at, edited_at)
VALUES (@name, @description, @userId, @data, NOW(), NOW())";

        public const string EditWorkQuery = @"
UPDATE public.work
SET name = @name
    description = @description,
    data = @data
    edited_at = NOW()
WHERE id = @id";

        public const string RemoveWorkQuery = @"
DELETE FROM public.work
WHERE id = @id";

        public const string GetWorkDetailsQuery = @"
SELECT w.name, w.description, u.user, w.data, w.published_at, w.edited_at
FROM public.work w
JOIN public.user u ON u.id = w.user_id";
        
        public const string GetWorksAllQuery = @"
SELECT w.name, u.user, w.preview
FROM public.work w
JOIN public.user u ON u.id = w.user_id";
        
        public const string GetWorksByFilterQuery = @"
SELECT w.name, u.user, w.preview
FROM public.work w
JOIN public.user u ON u.id = w.user_id
WHERE w.name LIKE @nameFilter
    AND ";
    }
}
