;;;; 2015-10-12 10:53:47
;;;; This is your lisp file. May it serve you well.

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

(defun lab2_atom_from_list_rec(x y)
  (cond
    ((= 0 y)
      (car x)
    )
    ((atom (car x))
      (lab2_atom_from_list_rec (cdr x) (- y 1))
    )
    ((not (atom (car x)))
      (lab2_atom_from_list_rec (cdr x) y)
    )
  )
)

;(LAB2_ATOM_FROM_LIST_REC (list 1 2 3 (list 4 5) 6 7) 2)
