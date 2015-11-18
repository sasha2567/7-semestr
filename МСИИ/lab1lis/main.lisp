;;;; 2015-10-12 10:53:47
;;;; This is your lisp file. May it serve you well.

;1 ����------------------------------------------------------------------------------------------------

(defun lab1_func_list(x y z)
  (let* ((l1 (list x y z)))
    (when (NUMBERP (second l1))
      (when (or (EQUAL (rem (second l1) 7) 0) (EQUAL (rem (second l1) 5) 0))
        (setf res l1)
        (setf (SECOND res) 35)
        res
      )
    )
    (and
      (append (list (first l1)) (cddr l1))
    )
  )
)

;2 ����------------------------------------------------------------------------------------------------

(defun lab2_atom_from_list(x y)
  (let* ((l2 x))
    (setf k 0)
    (dolist (z l2)
      (when (atom z)
        (setf k (+ k 1))
      )
      (when (= k y)
        (return z)
      )
    )
  )
)

(defun lab2_atom_from_list_rec(x y &optional z)
  (if(= 0 y)
    z
    (if (atom (car x))
	  (lab2_atom_from_list_rec (cdr x) (- y 1) (car x))
	  (lab2_atom_from_list_rec (cdr x) y (car x))
	)
  )
)


(defun lrtrace(n k)
  (trace lab2_atom_from_list_rec)
  (lab2_atom_from_list_rec n k)
  (untrace lab2_atom_from_list_rec)
)

;(LAB2_ATOM_FROM_LIST_REC (list 1 2 3 (list 4 5) 6 7) 2)
;(lrtrace (list 1 2 3 (list 4 5) 6 7) 2)

;3 ����------------------------------------------------------------------------------------------------

(defun CreateDB (a b c d e f g)
  (list (list :number a :fio b :yearb c :yearp d :markF e :markVM f :markPr g))
)

(defun AddRow(db a b c d e f g)
  (adjoin (list :number a :fio b :yearb c :yearp d :markF e :markVM f :markPr g) db)
)

(defun SaveDB(db filePath)
  (with-open-file (out filePath
                   :direction :output
                   :if-exists :supersede)
    (with-standard-io-syntax
      (print db out)
    )
  )
)

(defun ReadDB (filePath)
  (with-open-file (in filePath)
    (with-standard-io-syntax
      (read in)
    )
  )
)

(defun Update (db selector-func &key MarkF MarkVM MarkPr)
    (mapcar
      #'(lambda (record)
          (when (funcall selector-func record)
            (if MarkF (setf (getf record :markF) MarkF))
            (if MarkVM (setf (getf record :markVM) MarkVM))
            (if MarkPr (setf (getf record :markPr) MarkPr))
          )
          record
        )
      db
    )
 )

(defun NumberSelector (value)
  #'(lambda (x) (equal (getf x :number) value))
)

(defun GetFromBase(db mark)
  (format t "~%All troechniki~%")
  (setf count 0)
  (dolist (elem db)
    (cond 
      (
        (equal (getf elem :markF) mark) 
        (format t "~%|~{~a:~10t~a~10t~}|" 
          (list :number (getf elem :number) :fio (getf elem :fio))
        )
        (setf count (+ count 1))
      )
      (
        (equal (getf elem :markVM) mark) 
        (format t "~%|~{~a:~10t~a~10t~}|"
          (list :number (getf elem :number) :fio (getf elem :fio))
        )
        (setf count (+ count 1))
      )
      (
        (equal (getf elem :markPr) mark) 
        (format t "~%|~{~a:~10t|~a~10t~}|" 
          (list :number (getf elem :number) :fio (getf elem :fio))
        )
        (setf count (+ count 1))
      )
    )
  )
  (when (equal 0 count)
    (format t "~%~%Base have not troechniki~%")
  )
  (when (> count 0)
    (format t "~%~%Base have ~R troechniki~%" count)
  )
)

(defun PrintDB (db)
  (dolist (elem db)
    (format t "~%~{~a:~10t~a~%~}" elem)
  )
)
;----------------------------------------------------
(setf db (CreateDB 1 "Ikitjan" 1995 2012 5 3 4))
(setf db (AddRow db 2 "Lisajnsky" 1994 2012 5 5 5))
(setf db (AddRow db 3 "Dajdyshenko" 1994 2012 5 4 5))
(setf db (AddRow db 4 "Inal'ev" 1994 2012 4 3 4))
(PrintDB db)
(GetFromBase  db 3)
(setf db (Update db (NumberSelector 1) :markF 5 :markVM 4 :markPr 4))
(GetFromBase  db 3)
;(SaveDB db "D:\\file.dat")
;(setf db (ReadDB "D:\\file.dat"))
;(PrintDB db)
(format t "~%~%1994 is ~R ~%" 1994)