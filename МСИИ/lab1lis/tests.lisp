;;;; 2015-10-12 10:53:48
;;;; tests for your lisp code

(in-package :lab1lis)

(define-test main-test
  (assert-equal 0 (main)) ;should pass
  (assert-equal 1 (main)) ;should fail
)
