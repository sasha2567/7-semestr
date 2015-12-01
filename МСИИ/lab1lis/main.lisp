(defun CreateDB (a b c d e f g)
  (list (list :number a :fio b :yearb c :yearp d :markF e :markVM f :markPr g))
)

(defun AddRow(db a b c d e f g)
  (adjoin (list :number a :fio b :yearb c :yearp d :markF e :markVM f :markPr g) db)
)
(defun match (p d) 
  (cond  
    ;������� 1 
    ((and (null p)(null d)) t) 
    ;������� 2 
    ((and (null d) 
          (eq (car p) �$) 
          (null (cdr p))) t) 
    
    ; ���� �� ������� �������� 
    ((or (null p)(null d)) nil) 
    
    ;������� 3 � ������� 4 
    ((or (equal (car p) �?) 
         (equal (car p) (car d))) 
     (match (cdr p)(cdr d))) 
    
    ;������� 5 � 6 
    ((eq (car p) �$) 
     (cond ((match (cdr p) d) t) 
       ((match p (cdr d)) t)))
    ;������� 7
    ((and (not (atom (car p))) 
          (not (atom (car d))) 
          (match (car p)(car d))) 
     (match (cdr p) (cdr d)) )
    ;������� 8
    ((and (atom (car p))
          (eq (car-letter (car p)) #\$))
     ((match (cdr p)(cdr d))
      (set (cdr-name (car p)) (list (car d)))
      t)
     ((match p (cdr d))
      (set (cdr-name (car p))
           (cons (car d)(eval (cdr-name (car p)))))
      t)
     )
    ;������� 9 � 10
    ((and (not(atom (car p)))
          (eq (caar p) 'restrict)
          (eq (cadar p) '?)
          (and-to-list
           (mapcar #'(lambda (pred)
                       (funcall pred (car d))) (cddar p)
                   )))
     (match (cdr p)(cdr d)))
    ;������� 11
    ((and (not (atom (car p)))
          (not (atom d))
          (eq (caar p) 'restrict)
          (eq (car-letter (cadar p)) #\?)
          (and-to-list
           (mapcar #'(lambda (pred)
                       (funcall pred (car d))) (cddar p)))
          (match (cdr p)(cdr d)))
     (set (cdr-name (cadar p)) (car d))
     t)
    )
  )
(defun get-matches (p db)  ;db - ���� ������ ;p - ������ (�������)
  (cond ((null db) nil)
    ((match p (car db))
     (cons (car db) (get-matches p (cdr db)))
     )
    (t (get-matches p (cdr db)))
    )
  )
(defun car-letter (x) (if (not (numberp x)) (car (coerce (string x) 'list))))
(defun cdr-name (x)
  (intern (coerce (cdr (coerce (string x) 'list)) 'string)))
(defun and-to-list ( lis )
  (let ((res t))
    (dolist (temp lis res)
      (setq res (and res temp)))))
(defun zapros (db) 
    (cond 
      ((match '($ state in ?V $) (read))  
       (dolist (elem (get-matches (list ':number '? ':fio '? ':yearb '? ':yearp V ':markF '? ':markVM '? ':markPr '?) db)) 
         (format t "~%~{~a:~10t~a~%~}" (list :fio (getf elem :fio)) ))
      )
      ((match '($ born in ?V $) (read))  
       (dolist (elem (get-matches (list ':number '? ':fio '? ':yearb V ':yearp '? ':markF '? ':markVM '? ':markPr '?) db)) 
         (format t "~%~{~a:~10t~a~%~}" (list :fio (getf elem :fio)) ))
      )
      ((match '($ student ?S mark of programming $) (read))  
       (dolist (elem (get-matches (list ':number '? ':fio S ':yearb '? ':yearp '? ':markF '? ':markVM '? ':markPr '?) db)) 
         (format t "~%~{~a:~10t~a~%~}" (list :fio (getf elem :fio) :markPr  (getf elem :markPr)) ))
      )
      ((match '($ student ?S mark of fizics $) (read))  
       (dolist (elem (get-matches (list ':number '? ':fio S ':yearb '? ':yearp '? ':markF '? ':markVM '? ':markPr '?) db)) 
         (format t "~%~{~a:~10t~a~%~}" (list :fio (list :fio (getf elem :fio) :markF  (getf elem :markF)) ))
      )
      ((match '($ student ?S mark of mathematics $) (read))  
       (dolist (elem (get-matches (list ':number '? ':fio S ':yearb '? ':yearp '? ':markF '? ':markVM '? ':markPr '?) db)) 
         (format t "~%~{~a:~10t~a~%~}" (list :fio (getf elem :fio) :markVM  (getf elem :markVM)) ))
      )
      (t (princ "����������� ������"))
      )
    )
)

(setf db (CreateDB 1 "������" 1995 2012 5 3 4))
(setf db (AddRow db 2 "���������" 1994 2012 5 5 5))
(setf db (AddRow db 4 "���������" 1994 2012 5 4 5))
(setf db (AddRow db 5 "�������" 1994 2012 4 3 4))

;(zapros db)
;("������")