import { useState } from "react"

import Button from "../../components/Button/Button"
import ErrorForm from "../../components/Errors/ErrorForm/ErrorForm"
import Form from "../../components/Form/Form"
import Input from "../../components/Inputs/Input/Input"
import LinkForm from "../../components/Links/LinkForm/LinkForm"
import apiRoutes from "../../services/backend"

const Registration = () => {
    const [error, setError] = useState('')

    const onSubmit = async (e) =>{        
        e.preventDefault()
        const name = e.target.name.value.trim()
        const email = e.target.email.value.trim()
        const phone = e.target.phone.value.trim()
        const pass = e.target.pass.value.trim()
        const confirmPass = e.target.confirmPass.value.trim()
        
        if(pass !== confirmPass){
            setError('Senhas não são iguais')
        }
        else {
         const res = await apiRoutes.registration({name, email, phone, pass, confirmPass});
         console.log(res);
        }
        // console.log(name, email, phone, pass, confirmPass)  

    }

    return (
        <Form onSubmit={onSubmit} headerText='Cadastro' action="#">
            <Input type="text" name='name' placeholder="Nome" className="input" />
            <Input type="email" name='email' placeholder="Email" className="input" />
            <Input type="tel" name='phone' placeholder="Telefone" className="input" />
            <Input type="password" name='pass' placeholder="Senha" className="password" />
            <Input type="password" name='confirmPass' placeholder="Senha" className="password" />            
            <ErrorForm text={error}/>
            
            <Button text="Cadastrar"/>
            <LinkForm message='Já possui uma conta? ' link="/login" textLink="Login" />
        </Form>
    )
}

export default Registration